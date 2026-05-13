using Microsoft.AspNetCore.Mvc;
using MISA.Salary.BL.DTOs;

namespace MISA.Salary.API.Controllers.Base;

[ApiController]
[Route("api/v1/[controller]")]
public abstract class BaseController : ControllerBase
{
    protected IActionResult ApiResult<T>(ServiceResult<T> result)
    {
        if (!result.Success)
        {
            if (result.Errors.Count > 0 && result.Errors[0].Contains("Không tìm thấy"))
                return NotFound(result);
            return BadRequest(result);
        }
        return Ok(result);
    }
}
