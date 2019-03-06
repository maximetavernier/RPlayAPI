using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RPlay.API.Attributes;
using RPlay.Business.Services;
using RPlay.Business.Services.Users;

namespace RPlay.API.Controllers.Users
{
    [Route("[controller]")]
    public sealed class UsersController : BaseController
    {
        public UsersController(IConfiguration configuration)
            : base(configuration)
        {
        }

        [HttpGet, Authorize]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            if (users?.Any() ?? false)
                return Ok(users);
            return NotFound();
        }
    }
}