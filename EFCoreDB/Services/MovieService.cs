using EFCoreDB.Models;

namespace EFCoreDB.Services
{
    public class MovieService : CrudServices<Movie, int>
    {
        
        private readonly MyDBContext _dbContext;
        public MovieService(MyDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task AddAsync(Movie entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Movie>> GetAllSync()
        {
            throw new NotImplementedException();
        }

        public Task<Movie> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Movie entity)
        {
            throw new NotImplementedException();
        }


        // Implement methods....
    }
}
