using MISA.Salary.BL.DTOs;
using MISA.Salary.DL.Entities;
using MISA.Salary.DL.Repositories;

namespace MISA.Salary.BL.Services;

public class OrganizationService : IOrganizationService
{
    private readonly IOrganizationRepository _repo;

    public OrganizationService(IOrganizationRepository repo)
    {
        _repo = repo;
    }

    public async Task<ServiceResult<IEnumerable<Organization>>> GetAllActiveAsync()
    {
        var data = await _repo.GetActiveAsync();
        return ServiceResult<IEnumerable<Organization>>.Ok(data);
    }
}
