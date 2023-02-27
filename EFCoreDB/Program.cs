using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;
using EFCoreDB.Models;
using EFCoreDB.Services;

namespace EFCoreDB
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddDbContext<MyDBContext>(
            opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("default")));
            builder.Services.AddScoped<MovieService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
