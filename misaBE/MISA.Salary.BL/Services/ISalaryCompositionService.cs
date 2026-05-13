using MISA.Salary.BL.DTOs;
using MISA.Salary.BL.Services.Base;
using MISA.Salary.DL.Entities;

namespace MISA.Salary.BL.Services;

public interface ISalaryCompositionService : IBaseService<SalaryComposition, SalaryCompositionCreateDto, SalaryCompositionUpdateDto>
{
    Task<ServiceResult<PagedResult<SalaryComposition>>> GetPagedAsync(SalaryCompositionFilterDto filter);
    Task<ServiceResult<Guid>> CloneAsync(Guid id, SalaryCompositionCloneDto dto);
}
