using MISA.Salary.DL.Entities;
using MISA.Salary.DL.Repositories.Base;

namespace MISA.Salary.DL.Repositories;

public interface IGridConfigRepository : IBaseRepository<GridConfig>
{
    Task<IEnumerable<GridConfig>> GetByGridIdAsync(string gridId, string? userId = null);
    Task<int> SaveConfigAsync(string gridId, string? userId, IEnumerable<GridConfig> configs);
}
