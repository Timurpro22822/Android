using ASP.NET_Web_API.constants;
using ASP.NET_Web_API.Data.Entites.Identity;
using ASP.NET_Web_API.Helpers;
using ASP.NET_Web_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<UserEntity> _userManager;

        public AccountController(UserManager<UserEntity> userManager)
        {
            _userManager = userManager;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserViewModel model)
        {
            var imageName = string.Empty;
            if(!string.IsNullOrEmpty(model.ImageBase64))
            {
                imageName = ImageWorker.SaveImage(model.ImageBase64);
            }
            UserEntity user = new UserEntity()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Image = imageName,
                UserName = model.Email
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if(result.Succeeded)
            {
                result = await _userManager.AddToRoleAsync(user, Roles.User);
                return Ok();
            }

            return BadRequest();
        }
    }
}
