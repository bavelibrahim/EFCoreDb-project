using EFCoreDB.Models;

namespace EFCoreDB.Services
{
    public class MovieService : IMovieService
    {
        
        private readonly MyDBContext _dbContext;
        public MovieService(MyDBContext dbContext)
        {
            _dbContext = dbContext;
        }


        // Implement methods....
    }
}
