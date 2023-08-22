using basicwebapi.constants;
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

        ////
        public async Task<IActionResult> Login([FromBody] UserVm userVm)
        {
            ResponseData response = await _authService.SignIn(userVm);
            if (response.token == null)
            {
                return Unauthorized();
            }
            response.Message = StringConstants.LoginSuccess;


            return Ok(response);
        }


        [Route("api/[controller]/[action]")]
        [HttpPost]
        public async Task<IActionResult> RegisterUser(UserVm userVm)
        {
            int rval = await _authService.RegisterUser(userVm);
            if (rval == 0)

                return Ok(new ResponseData
                {
                    Message = StringConstants.Signuperr,
                    status = 0
                });


            else if (rval == 1)
                return Ok(new ResponseData
                {
                    Message = StringConstants.SignupSuccess,
                    status = 1
                });
            else
            {
                return Ok(new ResponseData
                {
                    Message = StringConstants.UserExists,
                    status = 0
                });

            }





        }
        [Route("api/[controller]/[action]")]
        [HttpPost]
        public async Task SignOut(TokenVm tokenVm)
        {
            try
            {
                _authService.RefreshTheToken(tokenVm);
            }
            catch (Exception Ex)
            {

                throw;
            }

        }
        [Route("api/[controller]/[action]")]
        [HttpPost]
        public async Task<IActionResult> RefreshToken([FromBody] TokenVm tokenVm)
        {
            try
            {
                var res = await _authService.RefreshTheToken(tokenVm);
                return res.status == 401 ? Ok(Unauthorized()) : Ok(res);
            }
            catch (Exception Ex)
            {
                return Ok(new ResponseData
                {
                    Message = Ex.Message,
                });

            }

        }


    }
}
