using FC.DAL.Interface;
using FC.DAL.Models;
using FC.DAL.Repositary;
using FC.Database.Context;
using Microsoft.Extensions.Logging;

namespace FCConsoleApp1
{
    public class Program
    {
        public QuickKartDbContext context;
        public FCRepo fCRepo;

        public Program(ILogger<IFcRepo> logger)
        {
            context = new QuickKartDbContext();
            fCRepo = new FCRepo(context, logger);
        }

        static void Main(string[] args)
        {
            var program = new Program(new LoggerFactory().CreateLogger<IFcRepo>());
            var categories = program.fCRepo.GetCategories();
            Console.WriteLine("----------------------------------");
            Console.WriteLine("CategoryId\tCategoryName");
            Console.WriteLine("----------------------------------");
            foreach (var category in categories)
            {
                Console.WriteLine("{0}\t\t{1}", category.CategoryId, category.CategoryName);
            }


            byte categoryId = 1;
            List<Product> lstProducts = program.fCRepo.GetProductsOnCategoryId(categoryId);
            if (lstProducts.Count == 0)
            {
                Console.WriteLine("No products available under the category = " + categoryId);
            }
            else
            {
                Console.WriteLine("{0,-15}{1,-30}{2,-15}{3,-10}{4}", "ProductId", "ProductName", "CategoryId", "Price", "QuantityAvailable");
                Console.WriteLine("---------------------------------------------------------------------------------------");
                foreach (var product in lstProducts)
                {
                    Console.WriteLine("{0,-15}{1,-30}{2,-15}{3,-10}{4}", product.ProductId, product.ProductName, product.CategoryId, product.Price, product.QuantityAvailable);
                }
            }


        }
    }
        }
  
