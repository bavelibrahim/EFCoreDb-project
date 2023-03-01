namespace EFCoreDB.Models
{
    public class StringHelper
    {
        public StringHelper() { }

        public string getConnectionString()
        {
            
            string dbContext = "Server=N-NO-01-01-8189\\SQLEXPRESS;Database=MoviesDb;Trusted_Connection=True;MultipleActiveResultSets=true; TrustServerCertificate=true;";
            return dbContext;
        }
    }
}
