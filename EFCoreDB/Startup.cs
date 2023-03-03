using EFCoreDB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;
using EFCoreDB.Services;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.OpenApi.Models;


namespace EFCoreDB
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        private readonly StringHelper stringHelper;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });

            services.AddControllers();

            services.AddDbContext<MyDBContext>(options =>
                options.UseSqlServer(stringHelper.getConnectionString()));
            services.AddScoped<MovieService>();
            services.AddScoped<CharacterService>();
            services.AddScoped<FranchiseService>();

            // Services
            services.AddScoped<MovieService>();
            services.AddScoped<FranchiseService>();
            services.AddScoped<CharacterService>();

            // Other services can be registered here

        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure the app here

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

        }
    }
}
