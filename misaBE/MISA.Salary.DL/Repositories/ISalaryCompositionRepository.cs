using MISA.Salary.DL.Entities;
using MISA.Salary.DL.Repositories.Base;

namespace MISA.Salary.DL.Repositories;

public interface ISalaryCompositionRepository : IBaseRepository<SalaryComposition>
{
    Task<(IEnumerable<SalaryComposition> Data, int TotalCount)> GetPagedAsync(
        string? keyword,
        Guid? organizationId,
        int? status,
        int page,
        int pageSize);

    Task<bool> IsCodeExistsAsync(string code, Guid? excludeId = null);
    Task<SalaryComposition?> GetByCodeAsync(string code);
    Task<Guid> CloneAsync(Guid id, string newCode, string newName, string? createdBy);
}
