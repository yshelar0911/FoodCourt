using Azure.Identity;
using FC.DAL.Interface;
using FC.DAL.Models;
using FC.Database.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FC.DAL.Repositary
{
    public class FCRepo : IFcRepo
    {
        private readonly QuickKartDbContext QuickKartDbContext;
        private readonly ILogger<IFcRepo> logger;
        public FCRepo(QuickKartDbContext quickKartDbContext, ILogger<IFcRepo> logger)
        {
            this.QuickKartDbContext = quickKartDbContext;
            this.logger = logger;
        }

        public List<Category> GetCategories()
        {
            List<Category> categories = null;
            try
            {
                categories = QuickKartDbContext.Categories.ToList();
            }
            catch (Exception ex)
            {
                logger.LogError($"Error in GetCategories: {ex.Message}");
                return null;
            }
            return categories != null ? categories : new List<Category>();
        }

        public List<Product> GetProductsOnCategoryId(byte categoryId)
        {
            List<Product> products = new List<Product>();
            try
            {
                products = (from product in QuickKartDbContext.Products where product.CategoryId == categoryId select product).ToList();

            }
            catch (Exception ex)
            {
                logger.LogError($"Error in GetProductsOnCategoryId: {ex.Message}");
                products = null;
            }
            return products != null ? products : new List<Product>();
        }

        public bool Login(string username, string password)
        {
            bool status = false;
            try
            {
                var user = QuickKartDbContext.Users.Where(u => u.EmailId == username && u.UserPassword == password).FirstOrDefault();
                if (user != null)
                {
                    status = true;
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Error in Login: {ex.Message}");
                status = false;
            }
            return status;
        }

        public bool resisterUser(string userName,string emailId, string password, char gender,  DateOnly date, string address)
        {
            bool status = false;
            int noOfrows = 0;
            int result = 0;

            try
            {
                SqlParameter prmPass = new SqlParameter("@UserPassword", password);
                SqlParameter prmEmail = new SqlParameter("@EmailId", emailId);
                SqlParameter prmGender = new SqlParameter("@Gender", gender);
                SqlParameter prmDate = new SqlParameter("@DateOfBirth", date);
                SqlParameter prmAddress = new SqlParameter("@Address", address);
                SqlParameter prmUserName = new SqlParameter("@UserName", userName);

                SqlParameter prmReturnResult = new SqlParameter("@ReturnResult", System.Data.SqlDbType.Int);
                prmReturnResult.Direction = System.Data.ParameterDirection.Output;

                noOfrows= QuickKartDbContext.Database.ExecuteSqlRaw("exec usp_RegisterUser @UserPassword,@Gender,@EmailId,@DateOfBirth,@Address,@UserName",  prmPass,  prmGender, prmEmail, prmDate, prmAddress, prmUserName);
                
                if(noOfrows > 0)
                {
                    status = true;
                    //result = Convert.ToInt32(prmReturnResult.Value);
                }
            }
            catch (Exception ex)
            {//
                status = false;
                logger.LogError($"Error in resisterUser: {ex.Message}");

            }
            return status;
        }
    }
}