﻿using ASP.NET_Web_API.Data;
using ASP.NET_Web_API.Data.Entites;
using ASP.NET_Web_API.Helpers;
using ASP.NET_Web_API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly AppEFContext _appEFContext;

        public CategoriesController(AppEFContext appEFContext, IMapper mapper)
        {
            _mapper = mapper;
            _appEFContext = appEFContext;
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetAll()
        {
            var model = await _appEFContext.Categories
                .Where(x => x.isDeleted == false)
                .OrderBy(x => x.Priority)
                .Select(x => _mapper.Map<CategoryItemViewModel>(x))
                .ToListAsync();

            return Ok(model);
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CategoryCreateItemVM model)
        {
            try
            {
                var cat = _mapper.Map<CategoryEntity>(model);
                cat.Image = ImageWorker.SaveImage(model.ImageBase64);
                await _appEFContext.Categories.AddAsync(cat);
                await _appEFContext.SaveChangesAsync();
                return Ok(_mapper.Map<CategoryItemViewModel>(cat));

            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
