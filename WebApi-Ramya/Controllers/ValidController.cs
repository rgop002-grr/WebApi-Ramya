
using Microsoft.AspNetCore.Mvc;

namespace WebApi_Ramya.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValidController : ControllerBase
    {
        
            private const string StaticToken = "12345ABCDE";

            [HttpGet("data")]
            public IActionResult GetData([FromHeader(Name = "Authorization")] string? authorization)
            {
                if (string.IsNullOrWhiteSpace(authorization))
                    return Unauthorized(new { Message = "Token is missing. Please send 'Authorization: Bearer 12345ABCDE'" });

                string token = authorization.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase)
                    ? authorization.Substring("Bearer ".Length).Trim()
                    : authorization.Trim();

                if (token != StaticToken)
                    return Unauthorized(new { Message = "Invalid token." });

                return Ok(new { Message = "✅ Token validated successfully!", Data = "This is your secure data." });
            }
        }
    }

        