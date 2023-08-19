using BasicWebApi.IService.IService;
using BasicWebApi.ViewModel.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace basicwebapi.Controllers
{
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [AllowAnonymous]
        [Route("api/[controller]/[action]")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserVm userVm)
        {
            string token = await _authService.SignIn(userVm);
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(
           new TokenVm
           {
               JwtToken = token,
               RefreshToken = "",
           });
        }
        [Route("api/[controller]/[action]")]
        [HttpPost]
        public async Task<IActionResult> RegisterUser(UserVm userVm)
        {
            return Ok();
        }
        [Route("api/[controller]/[action]")]
        [HttpPost]
        public async Task SignOut()
        {

        }
    }
}
