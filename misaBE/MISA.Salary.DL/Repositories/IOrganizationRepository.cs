using MISA.Salary.DL.Entities;
using MISA.Salary.DL.Repositories.Base;

namespace MISA.Salary.DL.Repositories;

public interface IOrganizationRepository : IBaseRepository<Organization>
{
    Task<IEnumerable<Organization>> GetActiveAsync();
}
