using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebApi_Ramya.Models;

namespace WebApi_Ramya.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RefreshToken : ControllerBase
    {
       
            private readonly IConfiguration _config;

            // Store refresh tokens temporarily (for demo)
            private static List<(string Username, string RefreshToken)> _refreshTokens = new();

        public RefreshToken(IConfiguration config)
            {
                _config = config;
            }

            // ---------------- LOGIN ----------------
            [HttpPost("login")]
            public IActionResult Login([FromBody] LoginRequest request)
            {
                if (request == null)
                    return BadRequest("Request body is missing!");

                // Dummy validation
                if (request.Username != "ramya" || request.Password != "1234")
                    return Unauthorized("Invalid username or password!");

                var tokens = GenerateTokens(request.Username);
                return Ok(tokens);
            }

            // ---------------- REFRESH TOKEN ----------------
            [HttpPost("refresh")]
        
        public IActionResult Refresh([FromBody] TokenResponse request)
        {
            if (request == null)
                return BadRequest("Request body is missing!");

            // Check if user and refresh token exist
            var storedToken = _refreshTokens.FirstOrDefault(u => u.Username == request.Username);

            if (storedToken == default || storedToken.RefreshToken != request.RefreshToken)
                return Unauthorized("Invalid refresh token!");

            // ✅ Generate a new Access Token only (don’t generate refresh token again)
            var newAccessToken = GenerateTokens(request.Username);

            // ✅ Return only the new Access Token
            return Ok(new { AccessToken = newAccessToken });
        }


        // ---------------- TOKEN GENERATION METHOD ----------------
        private TokenResponse GenerateTokens(string username)
            {
                var key = Encoding.UTF8.GetBytes(_config["Jwt:Key"]);
                var tokenHandler = new JwtSecurityTokenHandler();

                var now = DateTime.UtcNow;

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, "Admin")
                }),
                    Issuer = _config["Jwt:Issuer"],
                    Audience = _config["Jwt:Audience"],

                    NotBefore = now,
                    IssuedAt = now,
                    Expires = now.AddMinutes(2),

                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                var accessToken = tokenHandler.WriteToken(token);

                string refreshToken = Guid.NewGuid().ToString();

                var existing = _refreshTokens.FirstOrDefault(u => u.Username == username);
                if (existing != default)
                    _refreshTokens.Remove(existing);

                _refreshTokens.Add((username, refreshToken));

                return new TokenResponse
                {
                    Username = username,
                    AccessToken = accessToken,
                    RefreshToken = refreshToken
                };
            }
        }
    }

