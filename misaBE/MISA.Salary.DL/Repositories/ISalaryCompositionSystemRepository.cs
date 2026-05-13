using MISA.Salary.DL.Entities;
using MISA.Salary.DL.Repositories.Base;

namespace MISA.Salary.DL.Repositories;

public interface ISalaryCompositionSystemRepository : IBaseRepository<SalaryCompositionSystem>
{
    Task<(IEnumerable<SalaryCompositionSystem> Data, int TotalCount)> GetPagedAsync(
        string? keyword, int? status, int page, int pageSize);
    Task<IEnumerable<SalaryCompositionSystem>> GetAvailableAsync(IEnumerable<string> excludeCodes);
}
