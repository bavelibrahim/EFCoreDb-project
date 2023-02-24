using EFCoreDB.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDB.Services
{
    public class MovieService
    {
        private readonly MyDBContext _context;

        public MovieService(MyDBContext context)
        {
            _context = context;
        }

        public async Task<List<Movie>> GetAllMoviesAsync()
        {
            return await _context.movies.ToListAsync();
        }

        // Other CRUD operations for Movie entity can be added here
    }
}
