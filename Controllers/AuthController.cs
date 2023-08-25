using GymTraningApp.Models.Identity;
using GymTraningApp.services.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GymTraningApp.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserLoginService _userLoginService;
        private readonly IUserRegisterService _userRegisterService;

        public AuthController(IUserLoginService userLoginService, IUserRegisterService userRegisterService)
        {
            _userLoginService = userLoginService;
            _userRegisterService = userRegisterService;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequestService request)
        {
            bool loggedInSuccsesfully = await _userLoginService.Login(request.Name, request.Password, true);
            
            if(!loggedInSuccsesfully)
                return BadRequest();

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterRequestService request)
        {
            bool registeredSuccsesfully = await _userRegisterService.Register(
                request.Name,
                request.Password,
                request.Email
            );
            if(!registeredSuccsesfully)
                return BadRequest();
            
            return Ok();
        }
    }
}