using MISA.Salary.BL.DTOs;
using MISA.Salary.DL.Entities;

namespace MISA.Salary.BL.Services;

public class SalaryCompositionSystemFilterDto
{
    public string? Keyword { get; set; }
    public int? Status { get; set; }
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 20;
}

public interface ISalaryCompositionSystemService
{
    Task<ServiceResult<PagedResult<SalaryCompositionSystem>>> GetPagedAsync(SalaryCompositionSystemFilterDto filter);
    Task<ServiceResult<IEnumerable<SalaryCompositionSystem>>> GetAvailableAsync();
    Task<ServiceResult<SalaryCompositionSystem>> GetByIdAsync(Guid id);
}
