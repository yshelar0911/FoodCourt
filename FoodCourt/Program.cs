
using Microsoft.AspNetCore;
using Microsoft.Identity.Client;

namespace FoodCourt
{
    public class Program
    {
        public static void Main(string[] args)
        {
           CreateWebHostBuilder(args).Build().Run();
        }

        //public static IHostBuilder CreateWebHostBuilder(string[] args) =>
        //    Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder =>
        //    { 
        //        webBuilder.UseStartup<Startup>();
        //    });

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)=>
          WebHost.CreateDefaultBuilder(args).UseStartup<Startup>();
            }

    }





