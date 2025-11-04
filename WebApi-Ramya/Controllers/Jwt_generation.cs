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

        // POST: api/Jwt_generation/generate
        [HttpPost("generate")]
        public IActionResult GenerateToken([FromBody] LoginRequest request)
        {
            if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Role))
                return BadRequest("Username and Role are required!");

            // --- Static secret key (should be at least 32 characters) ---
            var secretKey = "ThisIsAStaticSecretKeyForJwtToken123!";

            // --- Create claims based on user input ---
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, request.Username),
                new Claim(ClaimTypes.Role, request.Role),
                new Claim("Department", "DotNetTeam")
            };

            // --- Create signing key ---
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            // --- Create signing credentials ---
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // --- Create the JWT token ---
            var token = new JwtSecurityToken(
                issuer: "https://yourapp.com",
                audience: "https://yourapp.com",
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
            );

            // --- Convert token to string ---
            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            // --- Return token as response ---
            return Ok(new
            {
                Username = request.Username,
                Role = request.Role,
                Token = tokenString
            });
        }
    }
}

     
