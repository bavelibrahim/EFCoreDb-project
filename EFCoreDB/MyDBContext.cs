using Microsoft.EntityFrameworkCore;
using System.Data;

namespace EFCoreDB
{
    public class MyDBContext : DbContext
    {
        public DbSet<Movie>? movies;
        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
        {
        }
    }
}
