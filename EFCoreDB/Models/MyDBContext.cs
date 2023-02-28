using Microsoft.EntityFrameworkCore;
using System.Threading;

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



            modelBuilder.Entity<Franchise>().HasData(
            new Franchise { FranchiseId = 1, Name = "Marvel Cinematic Universe", Description = "A series of superhero films produced by Marvel Studios" },
            new Franchise { FranchiseId = 2, Name = "Star Wars", Description = "An epic space-opera media franchise" },
            new Franchise { FranchiseId = 3, Name = "Harry Potter", Description = "A series of fantasy novels written by J. K. Rowling" }
        );

            modelBuilder.Entity<Movie>().HasData(
                new Movie { MovieId = 1, Title = "Avengers: Endgame", Genre = "Action, Adventure, Sci-Fi", ReleaseYear = "2019", Director = "Anthony Russo, Joe Russo", PictureUrl = "https://www.imdb.com/TooDamnLongMovie", TrailerUrl = "https://www.youtube.com/watch?v=TcMBFSGVi1c", FranchiseId = 1 },
                new Movie { MovieId = 2, Title = "Star Wars: Episode IV - A New Hope", Genre = "Action, Adventure, Fantasy", ReleaseYear = "1977", Director = "George Lucas", PictureUrl = "https://www.imdb.com/WaveTheSaberMyFriend", TrailerUrl = "https://www.youtube.com/watch?v=1g3_CFmnU7k", FranchiseId = 2 },
                new Movie { MovieId = 3, Title = "Harry Potter and the Philosopher's Stone", Genre = "Adventure, Family, Fantasy", ReleaseYear = "2001", Director = "Chris Columbus", PictureUrl = "https://www.imdb.com/HarrysParrentDidNotLikeHim", TrailerUrl = "https://www.youtube.com/watch?v=VyHV0BRtdxo", FranchiseId = 3 }
            );

            modelBuilder.Entity<Character>().HasData(
                new Character { CharacterId = 1, Name = "Iron Man (Tony Stark)", Alias = "Iron Man", Gender = "Male", PictureUrl = "https://www.imdb.com/HeDiedInVain", MovieId = 1 },
                new Character { CharacterId = 2, Name = "Luke Skywalker", Alias = null, Gender = "Male", PictureUrl = "https://www.imdb.com/title/IamNotYourDaddy", MovieId = 2 },
                new Character { CharacterId = 3, Name = "Harry Potter", Alias = null, Gender = "Male", PictureUrl = "https://www.imdb.com/title/itsWingardiumLeviOsaNotLeviOsa", MovieId = 3 }
            );
        }
    }
}
