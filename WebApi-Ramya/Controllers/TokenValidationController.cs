using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

namespace WebApi_Ramya.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TokenValidationController : ControllerBase
    {
       
            // -----------------------------
            // Public endpoint (no token required)
            // -----------------------------
            [HttpGet("public")]
            public IActionResult PublicEndpoint()
            {
                return Ok("Public endpoint — no token required.");
            }

            // -----------------------------
            // Protected endpoint (JWT token required)
            // -----------------------------
            
            [HttpGet("protected")]
            public IActionResult ProtectedEndpoint()
            {
                // Access claims from the JWT
                var userName = User.Identity?.Name ?? "Unknown";
                var role = User.IsInRole("Admin") ? "Admin" : "User";

                return Ok(new
                {
                    message = $"Hello {userName}, you have accessed a protected endpoint!",
                    role = role
                });
            }

            // -----------------------------
            // Role-based protected endpoint (Admin only)
            // -----------------------------
            [Authorize(Roles = "Admin")]
            [HttpGet("admin-only")]
            public IActionResult AdminOnlyEndpoint()
            {
                return Ok("This endpoint is accessible only to Admins!");
            }
        }
    }

