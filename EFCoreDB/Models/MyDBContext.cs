using Microsoft.EntityFrameworkCore;

namespace EFCoreDB.Models
{
    public class MyDBContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; } = null!;
        public DbSet<Character> Characters { get; set; } = null!;
        public DbSet<Franchise> Franchises { get; set; } = null!;

        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
                .HasMany(m => m.Characters)
                .WithMany(c => c.Movies)
                .UsingEntity(j => j.ToTable("MovieCharacters"));

            modelBuilder.Entity<Franchise>()
                .HasMany(f => f.Movies)
                .WithOne(m => m.Franchise)
                .HasForeignKey(m => m.FranchiseId);
        }
    }
}
