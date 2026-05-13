using Microsoft.AspNetCore.Mvc;
using MISA.Salary.API.Controllers.Base;
using MISA.Salary.BL.Services;
using MISA.Salary.DL.Entities;

namespace MISA.Salary.API.Controllers;

/// <summary>
/// API lưu/lấy cấu hình cột lưới
/// </summary>
public class GridConfigController : BaseController
{
    private readonly IGridConfigService _service;

    public GridConfigController(IGridConfigService service)
    {
        _service = service;
    }

    /// <summary>GET /api/v1/gridconfig/{gridId}?userId=</summary>
    [HttpGet("{gridId}")]
    public async Task<IActionResult> GetConfig(string gridId, [FromQuery] string? userId = null)
    {
        var result = await _service.GetConfigAsync(gridId, userId);
        return ApiResult(result);
    }

    /// <summary>POST /api/v1/gridconfig/{gridId}?userId=</summary>
    [HttpPost("{gridId}")]
    public async Task<IActionResult> SaveConfig(string gridId, [FromQuery] string? userId, [FromBody] IEnumerable<GridConfig> configs)
    {
        var result = await _service.SaveConfigAsync(gridId, userId, configs);
        return ApiResult(result);
    }
}
