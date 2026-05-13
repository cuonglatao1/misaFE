using MISA.Salary.BL.DTOs;
using MISA.Salary.DL.Entities;

namespace MISA.Salary.BL.Services;

public interface IGridConfigService
{
    Task<ServiceResult<IEnumerable<GridConfig>>> GetConfigAsync(string gridId, string? userId = null);
    Task<ServiceResult<int>> SaveConfigAsync(string gridId, string? userId, IEnumerable<GridConfig> configs);
}
