using EFCoreDB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;
using EFCoreDB.Services;

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


            services.AddControllers();

            services.AddDbContext<MyDBContext>(options =>
                options.UseSqlServer(stringHelper.getConnectionString()));
            services.AddScoped<MovieService>();
            services.AddScoped<CharacterService>();
            services.AddScoped<FranchiseService>();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure the app here
        }
    }
}
