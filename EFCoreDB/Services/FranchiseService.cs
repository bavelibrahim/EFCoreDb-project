using EFCoreDB.Models;

namespace EFCoreDB.Services
{
    public class FranchiseService : CrudServices<Franchise, int>
    {

        private readonly MyDBContext _dbContext;
        public FranchiseService(MyDBContext dbContext) 
        { 
            _dbContext = dbContext;
        }

        public Task AddAsync(Franchise entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Franchise>> GetAllSync()
        {
            throw new NotImplementedException();
        }

        public Task<Franchise> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Franchise entity)
        {
            throw new NotImplementedException();
        }


        // Implement methods....
    }
}
