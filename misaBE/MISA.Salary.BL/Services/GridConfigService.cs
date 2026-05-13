using MISA.Salary.BL.DTOs;
using MISA.Salary.DL.Entities;
using MISA.Salary.DL.Repositories;

namespace MISA.Salary.BL.Services;

public class GridConfigService : IGridConfigService
{
    private readonly IGridConfigRepository _repo;

    public GridConfigService(IGridConfigRepository repo)
    {
        _repo = repo;
    }

    public async Task<ServiceResult<IEnumerable<GridConfig>>> GetConfigAsync(string gridId, string? userId = null)
    {
        var configs = await _repo.GetByGridIdAsync(gridId, userId);
        return ServiceResult<IEnumerable<GridConfig>>.Ok(configs);
    }

    public async Task<ServiceResult<int>> SaveConfigAsync(string gridId, string? userId, IEnumerable<GridConfig> configs)
    {
        var rows = await _repo.SaveConfigAsync(gridId, userId, configs);
        return ServiceResult<int>.Ok(rows, "Lưu cấu hình cột thành công");
    }
}
