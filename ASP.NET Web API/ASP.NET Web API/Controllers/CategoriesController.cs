using ASP.NET_Web_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace ASP.NET_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        [HttpGet("list")]
        public async Task<IActionResult> GetAll()
        {
            var list = new List<CategoryItemViewModel>()
            {
                new CategoryItemViewModel
                {
                    Id = 1,
                    Name = "Laptops",
                    Image = "/images/1.jpg"
                },
                new CategoryItemViewModel
                {
                    Id = 2,
                    Name = "Video cards",
                    Image = "/images/2.jpg"
                },
                new CategoryItemViewModel
                {
                    Id = 3,
                    Name = "RAM",
                    Image = "/images/3.jpg"
                }
            };

            return Ok(list);
        }
    }
}
