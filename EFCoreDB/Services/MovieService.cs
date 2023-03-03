using EFCoreDB.Models;
using EFCoreDB.Util.Exeptions;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDB.Services
{
    public class MovieService : CrudServices<Movie, int>
    {

        private readonly MyDBContext _dbContext;
        private readonly ILogger<MovieService> _logger;
        public MovieService(MyDBContext dbContext, ILogger<MovieService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        /// <summary>
        /// Adds a new Movie to the DbContext
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task AddAsync(Movie entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes Movie by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(int id)
        {
            var movie = await _dbContext.Movies.FindAsync(id);

            if (movie == null)
            {
                _logger.LogError("Movie with id: " + id + " is not found");
                throw new MovieNotFoundException();
            }

            // Removes movie and saves changes
            _dbContext.Movies.Remove(movie);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Obtains all movies.
        /// </summary>
        /// <returns></returns>
        public async Task<ICollection<Movie>> GetAllSync()
        {
            // The reason for using a select in this case is because of the occurence of an infinite loop (Many to many relationship)

            return await _dbContext.Movies
        .Select(c => new Movie
        {
            MovieId = c.MovieId,
            Title = c.Title,

            Characters = c.Characters.Select(m => new Character
            {
                MovieId = m.MovieId,
                Name = m.Name,
            }).ToList(),

            // Maybe Franchise too, not sure here....

        }).ToListAsync();
        }

        /// <summary>
        /// Obtain Franchise by Movie Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Franchise> GetFranchiseByMovieId(int id)
        {
            var movie = await _dbContext.Movies.Where(m => m.MovieId == id)
                .Include(m => m.Franchise)
                .FirstOrDefaultAsync();

            if (movie.Franchise == null)
            {
                throw new MovieNotFoundException();
            }

            return movie.Franchise;
        }

        /// <summary>
        /// Obtains character by Movie Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ICollection<Character>> GetCharactersByMovieId(int id)
        {
            var movie = await GetMovieById(id);

            // Returns the movies of the character
            return movie.Characters.Select(m => new Character
            {
                CharacterId = m.CharacterId,
                Name = m.Name,
                // can add further properties if needed
            }).ToList();
        }

        /// <summary>
        /// Obtains Movie by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Movie> GetMovieById(int id)
        {
            if (!await MovieExists(id))
            {
                _logger.LogError($"Movie not found with Id: {id}");
                throw new MovieNotFoundException();
            }

            // Returns the Movie and the Movies' characters. 
            return await _dbContext.Movies.Where(p => p.MovieId == id)
                .Include(p => p.Characters)
                .FirstAsync();
        }

        /// <summary>
        /// Updates a existing entity inside the DbContext
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task UpdateAsync(Movie entity)
        {
            if (!await MovieExists(entity.MovieId))
            {
                _logger.LogError($"Movie not found with id: {entity.MovieId}");
                throw new MovieNotFoundException();
            }

            // Enter the modified entry and save the changes
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

        }

        public async Task UpdateCharacters(int[] characterIds, int movieId)
        {
            if (!await MovieExists(movieId))
            {
                _logger.LogError("Movie not found with Id: " + movieId);
                throw new MovieNotFoundException();
            }
            List<Character> characters = characterIds
                .ToList()
                .Select(sid => _dbContext.Characters
                .Where(s => s.CharacterId == sid).First())
                .ToList();
            // Get movie for Id
            Movie movie = await _dbContext.Movies
                .Where(p => p.MovieId == movieId)
                .FirstAsync();
            // Set the movie characters
            movie.Characters = characters;
            _dbContext.Entry(movie).State = EntityState.Modified;
            // Save all the changes
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Checks if a certain Movie exist by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private async Task<bool> MovieExists(int id)
        {
            return await _dbContext.Movies.AnyAsync(e => e.MovieId == id);
        }

        // Implement methods....
    }
}
