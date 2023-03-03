using EFCoreDB.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDB.Services
{
    public class FranchiseService : CrudServices<Franchise, int>
    {

        private readonly MyDBContext _dbContext;
        private readonly ILogger<FranchiseService> _logger;
        public FranchiseService(MyDBContext dbContext, ILogger<FranchiseService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        /// <summary>
        /// Adds a new Franchise to the DbContext
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task AddAsync(Franchise entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes Franchise by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(int id)
        {
            var franchise = await _dbContext.Franchises.FindAsync(id);

            if (franchise == null)
            {
                _logger.LogError("Movie with id: " + id + " is not found");
                // Throw a new exception when it is not found
            }

            // Removes franchise and saves changes
            _dbContext.Franchises.Remove(franchise);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Obtains all Franchises.
        /// </summary>
        /// <returns></returns>
        public async Task<ICollection<Franchise>> GetAllSync()
        {
            // The reason for using a select in this case is because of the occurence of an infinite loop (Many to many relationship)

            return await _dbContext.Franchises
        .Select(c => new Franchise
        {
            FranchiseId = c.FranchiseId,
            Name = c.Name,

            Movies = c.Movies.Select(m => new Movie
            {
                MovieId = m.MovieId,
                Title = m.Title,
                Characters = m.Characters.ToList() ?? new List<Character>()
            }).ToList()
        }).ToListAsync();
        }

        /// <summary>
        /// Obtains Franchise by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>

        public async Task<Franchise> GetFranchiseById(int id)
        {
            if (!await FranchiseExists(id))
            {
                _logger.LogError($"Movie not found with Id: {id}");
                // Throw new exception here
            }

            // Returns the Franchise and the Franchises' movies. 
            return await _dbContext.Franchises.Where(p => p.FranchiseId == id)
                .Include(p => p.Movies)
                .FirstAsync();
        }

        public Task<Franchise> GetMovieById(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Obtain movies by Franchise Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ICollection<Movie>> GetMoviesByFranchiseId(int id)
        {
            var franchise = await _dbContext.Franchises.Where(m => m.FranchiseId == id)
                .Include(m => m.Movies)
                .FirstOrDefaultAsync();

            if (franchise.Movies == null)
            {
                //throw null exception for franchise
            }

            return franchise.Movies;
        }

        /// <summary>
        /// Updates a existing entity inside the DbContext
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task UpdateAsync(Franchise entity)
        {
            if (!await FranchiseExists(entity.FranchiseId))
            {
                _logger.LogError($"Movie not found with id: {entity.FranchiseId}");
                // Throw exception here
            }

            // Enter the modified entry and save the changes
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

        }

        public async Task UpdateMovies(int[] movieIds, int franchiseId)
        {
            if (!await FranchiseExists(franchiseId))
            {
                _logger.LogError("Franchise not found with Id: " + franchiseId);
                /* throw new FranchiseNotFoundException();*/
            }
            List<Movie> movies = movieIds
                .ToList()
                .Select(sid => _dbContext.Movies
                .Where(s => s.MovieId == sid).First())
                .ToList();
            // Get franchise for Id
            Franchise franchise = await _dbContext.Franchises
                .Where(p => p.FranchiseId == franchiseId)
                .FirstAsync();
            // Set the franchise movies
            franchise.Movies = movies;
            _dbContext.Entry(franchise).State = EntityState.Modified;
            // Save all the changes
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Checks if a certain Franchise exist by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private async Task<bool> FranchiseExists(int id)
        {
            return await _dbContext.Franchises.AnyAsync(e => e.FranchiseId == id);
        }
    }
}
