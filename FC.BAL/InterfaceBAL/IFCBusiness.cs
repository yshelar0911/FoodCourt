using FC.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FC.BAL.InterfaceBAL
{
    public interface IFCBusiness
    {
        public List<Category> Category();
        public List<Product> GetProductsOnCategoryId(byte categoryId);  

        public bool UserLogin(string username, string password);

        public bool NewLogin(string userName, string emailId, string password, char gender, DateOnly date, string address);



    }
}
