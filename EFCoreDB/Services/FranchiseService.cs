using EFCoreDB.Models;

namespace EFCoreDB.Services
{
    public class FranchiseService : IFranchiseService
    {

        private readonly MyDBContext _dbContext;
        public FranchiseService(MyDBContext dbContext) 
        { 
            _dbContext = dbContext;
        }


        // Implement methods....
    }
}
