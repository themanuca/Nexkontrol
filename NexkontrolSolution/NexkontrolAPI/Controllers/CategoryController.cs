using Application.Interfaces;
using Contract.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace NexkontrolAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        private Guid GetUserId()
        {
            var sub = User.FindFirstValue("codeVerify")
                      ?? throw new UnauthorizedAccessException("Token JWT inválido ou não contém o claim 'sub'.");

            return Guid.Parse(sub);
        }


        [HttpGet]
        public async Task<IActionResult> GetAllCategory()
        {
            try
            {
                var result = await _categoryService.GetAllCatgory();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Unauthorized(new { error = ex.Message });
            }
        
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryCreate categoryCreate)
        {
            var categorySummaryDto = new CategorySummaryDto();
            var userId = GetUserId();
            categorySummaryDto.UserId = userId;
            categorySummaryDto.CategoryName = categoryCreate.CategoryName;
            var id = await _categoryService.CreateCategory(categorySummaryDto);
            return Ok(id);
        }
        
    }
}