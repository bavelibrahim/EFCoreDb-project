namespace EFCoreDB.Services
{
    public interface CrudServices<T, ID>
    {
        Task<ICollection<T>> GetAllSync();

        Task<T> GetByIdAsync(ID id);

        Task AddAsync(T entity);

        Task UpdateAsync(T entity); 

        Task DeleteAsync(ID id);
    }
}
