using Microsoft.AspNetCore.Mvc;
using MISA.Salary.API.Controllers.Base;
using MISA.Salary.BL.Services;

namespace MISA.Salary.API.Controllers;

/// <summary>
/// API quản lý Danh mục thành phần lương hệ thống
/// </summary>
public class SalaryCompositionSystemController : BaseController
{
    private readonly ISalaryCompositionSystemService _service;

    public SalaryCompositionSystemController(ISalaryCompositionSystemService service)
    {
        _service = service;
    }

    /// <summary>GET /api/v1/salarycompositionsystem?keyword=&status=&page=1&pageSize=20</summary>
    [HttpGet]
    public async Task<IActionResult> GetPaged([FromQuery] SalaryCompositionSystemFilterDto filter)
    {
        var result = await _service.GetPagedAsync(filter);
        return ApiResult(result);
    }

    /// <summary>GET /api/v1/salarycompositionsystem/available</summary>
    [HttpGet("available")]
    public async Task<IActionResult> GetAvailable()
    {
        var result = await _service.GetAvailableAsync();
        return ApiResult(result);
    }

    /// <summary>GET /api/v1/salarycompositionsystem/{id}</summary>
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _service.GetByIdAsync(id);
        return ApiResult(result);
    }
}
