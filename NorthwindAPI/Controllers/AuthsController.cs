using Business.Abstract;
using Core.Entity.DTOs;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NorthwindAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : ControllerBase
    {
        IAuthService _authService;
        public AuthsController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("Register")]
        public IActionResult Register(UserRegisterDto userRegisterDto)
        {
            var result = _authService.Register(userRegisterDto, userRegisterDto.Password);
            if (result.Success)
            {
                var token = _authService.CreateAccessToken(result.Data);
                return Ok(token);
            }
            return BadRequest(result.Message);

        }
        [HttpPost("Login")]
        public IActionResult Login(UserLoginDto userLoginDto)
        {
            var result = _authService.Login(userLoginDto);
            if (result.Success)
            {
                var token = _authService.CreateAccessToken(result.Data);
                return Ok(token);
            }
            return BadRequest(result.Message);
        }
    }
}
