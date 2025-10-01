using Byway.Application.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace Byway.API.Controllers
{
    [ApiController]
    public class APIControllerBase : ControllerBase
    {
        protected IActionResult HandleResult<T>(Result<T> result)
        {
            if (result.IsSuccess)
            {
                return Ok(new { success = true, data = result.Value });
            }

            return StatusCode(result.Status ?? 400, new
            {
                success = false,
                error = result.ErrorMessage
            });
        }
        protected IActionResult HandleResult(Result result)
        {

            if (result.IsSuccess)
            {
                return Ok(new { success = true, data = true });
            }

            return StatusCode(result.Status ?? 400, new
            {
                success = false,
                error = result.ErrorMessage
            });

        }
    }
}
