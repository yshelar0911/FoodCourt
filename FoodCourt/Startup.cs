using FC.BAL.BAL;
using FC.BAL.InterfaceBAL;
using FC.DAL.Interface;
using FC.DAL.Repositary;
using FC.Database.Context;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;

namespace FoodCourt
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Add controllers and CORS
            services.AddControllers();
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy => policy
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

            // Add Newtonsoft JSON for serialization
            services.AddMvc(options => options.EnableEndpointRouting = false)
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ContractResolver = new DefaultContractResolver());

            // Add necessary services
            services.AddOptions();
            services.AddLogging();
            services.AddHttpContextAccessor();
            services.AddHttpClient();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            // Register DbContext (Fixing incorrect builder.Services usage)
            services.AddDbContext<QuickKartDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("QuickKartDBConnectionString")));

            // Register business logic and repository layer
            services.AddScoped<IFCBusiness, FCBuisness>();
            services.AddScoped<FCRepo>();
            services.AddScoped<IFcRepo, FCRepo>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable CORS, Swagger, and routing
            app.UseCors("AllowAll");
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

