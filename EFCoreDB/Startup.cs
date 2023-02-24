using EFCoreDB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EFCoreDB
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {

            string myDbContextConnectionString = _configuration.GetConnectionString("MyDBContext");

            // Register DbContext
            services.AddDbContext<MyDBContext>(options =>
                options.UseSqlServer(_configuration.GetConnectionString(myDbContextConnectionString)));

            // Other services can be registered here
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure the app here
        }
    }
}
