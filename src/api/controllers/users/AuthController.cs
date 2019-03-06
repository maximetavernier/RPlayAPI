using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RPlay.Business.Services.Users;
using RPlay.DTO.Options;

namespace RPlay.API.Controllers.Users
{
    [Route("[controller]")]
    public sealed class AuthController : BaseController
    {
        #region Services
        private readonly AuthService _authService;
        #endregion
        public AuthController(IConfiguration configuration) 
            : base(configuration)
        {
            _authService = new AuthService(configuration.GetSection("Auth").Get<AuthOptions>());
        }

        [HttpPost("login")]
        public IActionResult Login()
        {
            var auth = Request.Headers["Authorization"];
            var identity = _authService.Authenticate(auth);

            if (identity != null && _userService.ValidateAuthentication(identity)) {
                var user = _userService.GetUserByEmail(identity.Email);
                identity.Id = user.Id;
                identity.Password = _authService.ComputePassword(user.Id, user.Login, identity.Password);
                _userService.StartSession(identity);

                var jwt = _authService.CreateAuthToken(identity);
                if (!string.IsNullOrEmpty(jwt))
                    return Ok(new { jwt });
            }
            return Unauthorized();
        }

        [HttpDelete("logout"), Authorize]
        public IActionResult Logout()
        {
            return Ok();
        }
    }
}