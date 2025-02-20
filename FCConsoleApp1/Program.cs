using FC.DAL.Interface;
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


            var products = program.fCRepo.GetProductsOnCategoryId(1);
            Console.WriteLine("----------------------------------");
            Console.WriteLine("ProductId\tProductName\tCategoryId");
            Console.WriteLine("----------------------------------");
            foreach(var product in products)
            {
                Console.WriteLine(product.ProductId ); 
                Console.WriteLine(product.ProductName);
                Console.WriteLine(product.CategoryId);
            }
          
        
        }
    }
        }
  
