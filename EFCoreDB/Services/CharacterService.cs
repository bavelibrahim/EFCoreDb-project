using EFCoreDB.Models;

namespace EFCoreDB.Services
{
    public class CharacterService : CrudServices<Character, int>
    {

        private readonly MyDBContext _dbContext;
        public CharacterService(MyDBContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public Task AddAsync(Character entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Character>> GetAllSync()
        {
            throw new NotImplementedException();
        }

        public Task<Character> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Character entity)
        {
            throw new NotImplementedException();
        }

        // Implement methods....
    }
}
