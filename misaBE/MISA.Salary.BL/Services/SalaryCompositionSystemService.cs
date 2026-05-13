using MISA.Salary.BL.DTOs;
using MISA.Salary.DL.Entities;
using MISA.Salary.DL.Repositories;

namespace MISA.Salary.BL.Services;

public class SalaryCompositionSystemService : ISalaryCompositionSystemService
{
    private readonly ISalaryCompositionSystemRepository _systemRepo;
    private readonly ISalaryCompositionRepository _compositionRepo;

    public SalaryCompositionSystemService(
        ISalaryCompositionSystemRepository systemRepo,
        ISalaryCompositionRepository compositionRepo)
    {
        _systemRepo = systemRepo;
        _compositionRepo = compositionRepo;
    }

    public async Task<ServiceResult<PagedResult<SalaryCompositionSystem>>> GetPagedAsync(SalaryCompositionSystemFilterDto filter)
    {
        if (filter.Page < 1) filter.Page = 1;
        if (filter.PageSize < 1) filter.PageSize = 20;
        var (data, total) = await _systemRepo.GetPagedAsync(filter.Keyword, filter.Status, filter.Page, filter.PageSize);
        return ServiceResult<PagedResult<SalaryCompositionSystem>>.Ok(new PagedResult<SalaryCompositionSystem>
        {
            Data = data, TotalCount = total, Page = filter.Page, PageSize = filter.PageSize
        });
    }

    public async Task<ServiceResult<IEnumerable<SalaryCompositionSystem>>> GetAvailableAsync()
    {
        var all = await _compositionRepo.GetAllAsync();
        var usedCodes = all
            .Where(x => x.SourceType == 2 && x.SalaryCompositionSystemId.HasValue)
            .Select(x => x.SalaryCompositionCode)
            .ToList();
        var available = await _systemRepo.GetAvailableAsync(usedCodes);
        return ServiceResult<IEnumerable<SalaryCompositionSystem>>.Ok(available);
    }

    public async Task<ServiceResult<SalaryCompositionSystem>> GetByIdAsync(Guid id)
    {
        var entity = await _systemRepo.GetByIdAsync(id);
        if (entity == null) return ServiceResult<SalaryCompositionSystem>.Fail("Không tìm thấy danh mục hệ thống");
        return ServiceResult<SalaryCompositionSystem>.Ok(entity);
    }
}
