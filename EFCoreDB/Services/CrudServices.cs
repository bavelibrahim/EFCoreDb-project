namespace EFCoreDB.Services
{
    public interface CrudServices<T, ID>
    {
        Task<ICollection<T>> GetAllSync();

        Task AddAsync(T entity);

        Task UpdateAsync(T entity); 

        Task DeleteAsync(ID id);
    }
}
