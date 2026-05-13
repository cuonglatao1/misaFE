using Microsoft.AspNetCore.Mvc;
using MISA.Salary.API.Controllers.Base;
using MISA.Salary.BL.Services;

namespace MISA.Salary.API.Controllers;

/// <summary>
/// API lấy danh sách đơn vị công tác
/// </summary>
public class OrganizationController : BaseController
{
    private readonly IOrganizationService _service;

    public OrganizationController(IOrganizationService service)
    {
        _service = service;
    }

    /// <summary>GET /api/v1/organization</summary>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _service.GetAllActiveAsync();
        return ApiResult(result);
    }
}
