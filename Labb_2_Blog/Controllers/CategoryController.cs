using Labb_2_Blog.Core.Interface;
using Labb_2_Blog.Data.DTO;
using Labb_2_Blog.Data.Enteties;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Labb_2_Blog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]

        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return NotFound("Category not found");
            }
            return Ok(category);
        }

        [HttpPost]

        public async Task<IActionResult> AddCategory(AddCategoryDTO dto)
        {
            if (dto == null || string.IsNullOrWhiteSpace(dto.CategoryName))
            {
                return BadRequest("You need to fill in a category name");
            }

            var category = new Category
            {
                CategoryName = dto.CategoryName
            };

            var ok = await _categoryService.AddCategoryAsync(category);

            if (!ok)
            {
                return BadRequest("Something went wrong when adding the category");

            }
            else
            {
                return Ok(category);
            }
        }
    }
}
