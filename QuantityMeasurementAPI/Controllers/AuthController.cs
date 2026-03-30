using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore.Query;
using QuantityMeasurementAPI.DTOs;
using QuantityMeasurementModel.DTOs;
using QuantityMeasurementModel.Models;
using QuantityMeasurementServices.Interfaces;

namespace QuantityMeasurementAPI.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            var result = _authService.Register(request.Username, request.Password);
            return Ok(result);
        }
        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            var token = _authService.Login(request.Username, request.Password);
            return Ok(new { token });
        }

        [HttpPost("google-login")]
        [AllowAnonymous]
        public async Task<IActionResult> GoogleLogin([FromBody] GoogleLoginRequest request)
        {
            var token = await _authService.GoogleLogin(request.IdToken);
            return Ok(new { token });
        }
        [Authorize]
        [HttpGet("me")]
        public IActionResult GetCurrentUser()
        {
            var username = User.Identity?.Name;
            var email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;

            return Ok(new
            {
                username,
                email
            });
        }
    }
}