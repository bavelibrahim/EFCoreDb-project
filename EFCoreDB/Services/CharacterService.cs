using EFCoreDB.Models;

namespace EFCoreDB.Services
{
    public class CharacterService : ICharacterService
    {

        private readonly MyDBContext _dbContext;
        public CharacterService(MyDBContext dbContext) 
        {
            _dbContext = dbContext;
        }


        // Implement methods....
    }
}
