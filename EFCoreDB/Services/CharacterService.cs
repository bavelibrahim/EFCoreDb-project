using EFCoreDB.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDB.Services
{
    public class CharacterService : CrudServices<Character, int>
    {

        private readonly MyDBContext _dbContext;
        private readonly ILogger<CharacterService> _logger;

        /// <summary>
        /// Instantiating DbContext and the logger. Logger may not be necessary but it is helpful to check for errors.
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="logger"></param>
        public CharacterService(MyDBContext dbContext, ILogger<CharacterService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        /// <summary>
        /// Adds a new Character to the DbContext
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task AddAsync(Character entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(int id)
        {
            var character = await _dbContext.Characters.FindAsync(id);

            if (character == null)
            {
                _logger.LogError("Character with id: " + id + " is not found");
                // Throw a new exception when it is not found
            }

            // Removes and saves changes
            _dbContext.Characters.Remove(character);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Obtains all characters.
        /// </summary>
        /// <returns></returns>
        public async Task<ICollection<Character>> GetAllSync()
        {
            // The reason for using a select in this case is because of the occurence of an infinite loop (Many to many relationship)

            return await _dbContext.Characters
        .Select(c => new Character
        {
            CharacterId = c.CharacterId,
            Name = c.Name,
            // Add other properties as needed
            Movies = c.Movies.Select(m => new Movie
            {
                MovieId = m.MovieId,
                Title = m.Title,
                // Add other properties as needed
            }).ToList()
        }).ToListAsync();
        }

        /// <summary>
        /// Obtains character by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Character> GetByIdAsync(int id)
        {
            if (!await CharacterExists(id))
            {
                _logger.LogError($"Character not found with Id: {id}");
                // Throw new exception here
            }

            // Returns the character and the characters' movies. 
            return await _dbContext.Characters.Where(p => p.CharacterId == id)
                .Include(p => p.Movies).
                FirstAsync();

        }

        /// <summary>
        /// Updates a existing entity inside the DbContext
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task UpdateAsync(Character entity)
        {
            if(!await CharacterExists(entity.CharacterId))
            {
                _logger.LogError($"Character not found with id: {entity.CharacterId}");
                // Throw exception here
            }

            // Enter the modified entry and save the changes
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

        }

        /// <summary>
        /// Checks if a certain character exist by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private async Task<bool> CharacterExists(int id)
        {
            return await _dbContext.Characters.AnyAsync(e => e.CharacterId == id);
        }


        // Implement methods....
    }
}
