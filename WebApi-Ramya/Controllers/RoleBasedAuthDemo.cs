using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace WebApi_Ramya.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleBasedAuthDemo : ControllerBase
    {
        
            private readonly string _secretKey = "MyUltraSecretKeyForJwtRoleBasedAuth12345"; // must match Program.cs

            
           // ✅ Only Admins can access
            [Authorize(Roles = "Admin")]
            [HttpGet("admin-access")]
            public IActionResult AdminAccess()
            {
                // ✅ Access token details (Username & Role)
                var username = User.Identity?.Name; // from ClaimTypes.Name
                var role = User.FindFirst(ClaimTypes.Role)?.Value;

                return Ok(new
                {
                    Message = "Welcome Admin! You have full access.",
                    LoggedInUser = username,
                    Role = role
                });
            }

            // ✅ Only Users can access
            [Authorize(Roles = "User")]
            [HttpGet("user-access")]
            public IActionResult UserAccess()
            {
                // ✅ Read username & role from token
                var username = User.Identity?.Name;
                var role = User.FindFirst(ClaimTypes.Role)?.Value;

                return Ok(new
                {
                    Message = "Welcome User! You have limited access.",
                    LoggedInUser = username,
                    Role = role
                });
            }

            // ✅ Only Managers can access
            [Authorize(Roles = "Manager")]
            [HttpGet("manager-access")]
            public IActionResult ManagerAccess()
            {
                var username = User.Identity?.Name;
                var role = User.FindFirst(ClaimTypes.Role)?.Value;

                return Ok(new
                {
                    Message = "Welcome Manager! You can manage operations.",
                    LoggedInUser = username,
                    Role = role
                });
            }

            // ✅ Accessible by all roles (Admin, User, Manager)
            [Authorize(Roles = "Admin,User,Manager")]
            [HttpGet("common-access")]
            public IActionResult CommonAccess()
            {
                var username = User.Identity?.Name;
                var role = User.FindFirst(ClaimTypes.Role)?.Value;

                return Ok(new
                {
                    Message = "This endpoint can be accessed by Admin, User, or Manager.",
                    LoggedInUser = username,
                    Role = role
                });
            }
        }

        
      
    }



