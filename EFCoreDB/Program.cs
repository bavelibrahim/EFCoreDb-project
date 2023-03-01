using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;
using EFCoreDB.Models;
using EFCoreDB.Services;
using Microsoft.Extensions.Options;

namespace EFCoreDB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            StringHelper stringHelper = new StringHelper();

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddDbContext<MyDBContext>(
            opt => opt.UseSqlServer(stringHelper.getConnectionString()));
            builder.Services.AddScoped<MovieService>();
            builder.Services.AddScoped<CharacterService>();
            builder.Services.AddScoped<FranchiseService>();

            var options = builder.Services.BuildServiceProvider()
                                          .GetService<DbContextOptions<MyDBContext>>();

            using (var context = new MyDBContext(options))
            {
                context.Database.EnsureCreated();
            }

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();

            
        }
    }
}
