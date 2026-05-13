using MISA.Salary.BL.DTOs;

namespace MISA.Salary.BL.Services.Base;

public interface IBaseService<T, TCreate, TUpdate>
    where T : class
    where TCreate : class
    where TUpdate : class
{
    Task<ServiceResult<IEnumerable<T>>> GetAllAsync();
    Task<ServiceResult<T>> GetByIdAsync(Guid id);
    Task<ServiceResult<Guid>> CreateAsync(TCreate dto);
    Task<ServiceResult<int>> UpdateAsync(Guid id, TUpdate dto);
    Task<ServiceResult<int>> DeleteAsync(Guid id);
    Task<ServiceResult<int>> DeleteManyAsync(IEnumerable<Guid> ids);
}
