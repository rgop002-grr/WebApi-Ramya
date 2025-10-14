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
    public class Jwt_generation : ControllerBase
    {
       
       
            [HttpGet("generate")]
            public IActionResult GenerateToken()
            {
                // --- Static secret key (must be at least 32 characters for HS256) ---
                var secretKey = "ThisIsAStaticSecretKeyForJwtToken123!";

                // --- Create static claims (static data) ---
                var claims = new[]
                {
                new Claim(ClaimTypes.Name, "Ramya"),
                new Claim(ClaimTypes.Role, "Admin"),
                new Claim("Department", "DotNetTeam")
            };

                // --- Create signing key ---
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

                // --- Create signing credentials ---
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                // --- Create the token ---
                var token = new JwtSecurityToken(
                    issuer: "https://yourapp.com",
                    audience: "https://yourapp.com",
                    claims: claims,
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: creds
                );

                // --- Convert token to string ---
                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                // --- Return token to user ---
                return Ok(new { token = tokenString });
            }
        }
    }

