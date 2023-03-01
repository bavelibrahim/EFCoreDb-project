using EFCoreDB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;
using EFCoreDB.Services;

namespace EFCoreDB
{
    public class Startup
    {
        private const string ConnectionString = "MyDBContext";
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            string myDbContextConnectionString = ConnectionString;

            services.AddDbContext<MyDBContext>(options =>
                options.UseSqlServer(myDbContextConnectionString));

            // Services
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IFranchiseService, FranchiseService>();
            services.AddScoped<ICharacterService, CharacterService>();

            // Other services can be registered here
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure the app here
        }
    }
}
