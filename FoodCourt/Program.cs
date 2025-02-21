
using Microsoft.AspNetCore;
using Microsoft.Identity.Client;

namespace FoodCourt
{
    public class Program
    {
        public static void Main(string[] args)
        {
            #region
            //var builder = WebApplication.CreateBuilder(args);

            //// Add services to the container.

            //builder.Services.AddControllers();
            //// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            //builder.Services.AddEndpointsApiExplorer();
            //builder.Services.AddSwaggerGen();

            //var app = builder.Build();

            //// Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
            //    app.UseSwagger();
            //    app.UseSwaggerUI();
            //}

            //app.UseHttpsRedirection();

            //app.UseAuthorization();


            //app.MapControllers();

            //app.Run();
            #endregion
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





