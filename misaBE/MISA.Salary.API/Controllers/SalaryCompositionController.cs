using Microsoft.AspNetCore.Mvc;
using MISA.Salary.API.Controllers.Base;
using MISA.Salary.BL.DTOs;
using MISA.Salary.BL.Services;

namespace MISA.Salary.API.Controllers;

/// <summary>
/// API quản lý Thành phần lương
/// </summary>
public class SalaryCompositionController : BaseController
{
    private readonly ISalaryCompositionService _service;

    public SalaryCompositionController(ISalaryCompositionService service)
    {
        _service = service;
    }

    /// <summary>GET /api/v1/salarycomposition?keyword=&organizationId=&status=&page=1&pageSize=20</summary>
    [HttpGet]
    public async Task<IActionResult> GetPaged([FromQuery] SalaryCompositionFilterDto filter)
    {
        var result = await _service.GetPagedAsync(filter);
        return ApiResult(result);
    }

    /// <summary>GET /api/v1/salarycomposition/{id}</summary>
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _service.GetByIdAsync(id);
        return ApiResult(result);
    }

    /// <summary>POST /api/v1/salarycomposition</summary>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] SalaryCompositionCreateDto dto)
    {
        var result = await _service.CreateAsync(dto);
        if (!result.Success) return BadRequest(result);
        return CreatedAtAction(nameof(GetById), new { id = result.Data }, result);
    }

    /// <summary>PUT /api/v1/salarycomposition/{id}</summary>
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] SalaryCompositionUpdateDto dto)
    {
        var result = await _service.UpdateAsync(id, dto);
        return ApiResult(result);
    }

    /// <summary>DELETE /api/v1/salarycomposition/{id}</summary>
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _service.DeleteAsync(id);
        return ApiResult(result);
    }

    /// <summary>DELETE /api/v1/salarycomposition - xóa nhiều bản ghi</summary>
    [HttpDelete]
    public async Task<IActionResult> DeleteMany([FromBody] IEnumerable<Guid> ids)
    {
        var result = await _service.DeleteManyAsync(ids);
        return ApiResult(result);
    }

    /// <summary>POST /api/v1/salarycomposition/{id}/clone - nhân bản</summary>
    [HttpPost("{id:guid}/clone")]
    public async Task<IActionResult> Clone(Guid id, [FromBody] SalaryCompositionCloneDto dto)
    {
        var result = await _service.CloneAsync(id, dto);
        if (!result.Success) return BadRequest(result);
        return CreatedAtAction(nameof(GetById), new { id = result.Data }, result);
    }
}
