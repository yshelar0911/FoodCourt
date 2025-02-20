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
    }
}
