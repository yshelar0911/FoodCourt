using FC.BAL.InterfaceBAL;
using FC.DAL.Models;
using FC.DAL.Repositary;
using Microsoft.Identity.Client;

namespace FC.BAL.BAL
{
    public class FCBuisness : IFCBusiness
    {
        public FCRepo fCRepo;

        public FCBuisness(FCRepo fCRepo)
        {
            this.fCRepo = fCRepo;

        }

        public List<Category> Category()
        {
            List<Category> categories = null;
            try
            {
                categories = fCRepo.GetCategories();

            }
            catch (Exception ex)
            {
                categories = null;
            }

            return categories;
        }
        public List<Product> GetProductsOnCategoryId(byte categoryId)
        {
            List<Product> products = null;
            try
            {
                products = fCRepo.GetProductsOnCategoryId(categoryId);
            }
            catch (Exception ex)
            {
                products = null;
            }
            return products;
        }
    }
}