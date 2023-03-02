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
<<<<<<< HEAD
                options.UseSqlServer(stringHelper.getConnectionString()));
            services.AddScoped<MovieService>();
            services.AddScoped<CharacterService>();
            services.AddScoped<FranchiseService>();
=======
                options.UseSqlServer(myDbContextConnectionString));

            // Services
            services.AddScoped<MovieService>();
            services.AddScoped<FranchiseService>();
            services.AddScoped<CharacterService>();

            // Other services can be registered here
>>>>>>> origin/main
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure the app here
        }
    }
}
