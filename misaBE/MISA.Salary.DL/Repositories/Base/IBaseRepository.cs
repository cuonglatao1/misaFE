namespace MISA.Salary.DL.Repositories.Base;

public interface IBaseRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(Guid id);
    Task<Guid> InsertAsync(T entity);
    Task<int> UpdateAsync(T entity);
    Task<int> DeleteAsync(Guid id);
    Task<int> DeleteManyAsync(IEnumerable<Guid> ids);
}
