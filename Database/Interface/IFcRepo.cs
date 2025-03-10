using FC.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FC.DAL.Interface
{
    public interface IFcRepo
    {
       public List<Category> GetCategories();

        public List<Product> GetProductsOnCategoryId(byte categoryId);

        public bool Login(string username, string password);

        public bool resisterUser(string userName, string emailId, string password, char gender, DateOnly date, string address);


    }
}
