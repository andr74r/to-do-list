using Microsoft.AspNetCore.Mvc;
using ToDoList.Web.ViewModels;
using ToDoList.Core.Services.Category;
using System.Linq;
using AutoMapper;

namespace ToDoList.Web.ApiControllers
{
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(
            ICategoryService categoryService,
            IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [Route("api/categories")]
        [HttpGet]
        public IActionResult GetCategories()
        {
            var categories = _categoryService.GetUserCategories(1);

            var viewModel = categories
                .Select(c => _mapper.Map<CategoryViewModel>(c))
                .ToList();

            return Ok(viewModel);
        }
    }
}