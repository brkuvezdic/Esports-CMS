using EsportsCmsApplication.DTOs;
using EsportsCmsDomain.EntitiesNew;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http.HttpResults;
using System.IdentityModel.Tokens.Jwt;
using EsportsCmsApplication.Services;
using Microsoft.AspNetCore.Authorization;
namespace EsportsCmsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService, IConfiguration configuration) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDto request)
        {
            var user = await authService.RegisterAsync(request);
            if (user is null) {
                return BadRequest("Username already exists!");
            }
            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<TokenResponseDto>> Login(UserDto request)
        {
            var response = await authService.LoginAsync(request);
            if (response is null) {    
                return BadRequest("Invalid username or password.");
            }
            return Ok(response);
        }

        
        [HttpGet]
        [Authorize]

        public IActionResult AuthenticatedOnlyEndpoint()
        {

            return Ok("You are authetnicated");
        }
        [HttpGet("Admin-only")]
        [Authorize(Roles = "Admin")]

        public IActionResult AdminOnlyEndpoint()
        {

            return Ok("HI ADMIN");
        }

        [HttpPost("refresh-token")]
        public async Task<ActionResult<TokenResponseDto>> RefreshTokens(RefreshTokenRequestDto request)
        {
            var response = await authService.RefreshTokensAsync(request);
            if (response is null)
            {
                return Unauthorized("Invalid refresh token.");
            }
            return Ok(response);
        }
    }
}
