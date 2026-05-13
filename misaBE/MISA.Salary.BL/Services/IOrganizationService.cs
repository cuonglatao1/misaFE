using MISA.Salary.BL.DTOs;
using MISA.Salary.DL.Entities;

namespace MISA.Salary.BL.Services;

public interface IOrganizationService
{
    Task<ServiceResult<IEnumerable<Organization>>> GetAllActiveAsync();
}
