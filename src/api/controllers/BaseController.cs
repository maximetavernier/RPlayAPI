using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RPlay.Business.Services.Users;
using RPlay.DTO.Authentication;
using RPlay.DTO.DB;
using RPlay.DTO.Options;

namespace RPlay.API.Controllers
{
    public abstract class BaseController : Controller
    {
        #region Services
        protected readonly UserService _userService;
        #endregion

        #region C-Tor
        internal BaseController(IConfiguration configuration)
        {
            _userService = new UserService(configuration);
        }
        #endregion
    }
}