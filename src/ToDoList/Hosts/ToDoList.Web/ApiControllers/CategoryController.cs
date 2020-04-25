using Microsoft.AspNetCore.Mvc;
using ToDoList.Web.ViewModels;
using ToDoList.Core.Services.Category;
using System.Linq;
using AutoMapper;
using ToDoList.Core.Dto;

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

        [Route("api/categories")]
        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryViewModel saveViewModel)
        {
            var category = _categoryService.CreateCategory(saveViewModel.Name, 1);

            return Ok(_mapper.Map<CategoryViewModel>(category));
        }

        [Route("api/categories")]
        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryViewModel updateViewModel)
        {
            var category = _categoryService.UpdateCategory(
                _mapper.Map<CategoryDto>(updateViewModel));

            return Ok(_mapper.Map<CategoryViewModel>(category));
        }

        [Route("api/categories/{id}")]
        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            _categoryService.DeleteCategory(id);

            return Ok();
        }
    }
}