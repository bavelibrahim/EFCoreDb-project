namespace EFCoreDB.Services
{
    public interface CrudServices<T, ID>
    {
        Task<ICollection<T>> GetAllSync();

<<<<<<< HEAD
        Task<T> GetMovieById(ID id);

=======
>>>>>>> origin/main
        Task AddAsync(T entity);

        Task UpdateAsync(T entity); 

        Task DeleteAsync(ID id);
    }
}
