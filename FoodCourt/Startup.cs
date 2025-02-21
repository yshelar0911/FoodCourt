
using FC.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace FoodCourt
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddCors(option =>
            {
                option.AddPolicy("AllowAll", policy => policy
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            });
          services.AddMvc(option =>option.EnableEndpointRouting = false).AddNewtonsoftJson(Options => Options.SerializerSettings.ContractResolver = new DefaultContractResolver());
            services.AddOptions();
            services.AddLogging();
            services.AddHttpContextAccessor();
            services.AddHttpClient();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        services.AddDbContext<QuickKartDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("QuickKartDBConnectionString")));

            //services.AddEndpointsApiExplorer();
            //services.AddSwaggerGen();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if(env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
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
