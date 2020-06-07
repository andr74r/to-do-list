using Microsoft.AspNetCore.Mvc;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using ToDoList.Web.Extensions;
using ToDoList.Web.ViewModels.Category;
using MediatR;
using System.Threading.Tasks;
using ToDoList.Issue.Application.Queries;
using ToDoList.Issue.Application.Commands;

namespace ToDoList.Web.ApiControllers
{
    [Authorize]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CategoryController(
            IMediator mediator,
            IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [Route("api/categories")]
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _mediator.Send(new GetCategoriesQuery 
            { 
                UserId = User.Identity.UserId()
            });

            var viewModel = categories
                .Select(c => _mapper.Map<CategoryViewModel>(c))
                .ToList();

            return Ok(viewModel);
        }

        [Route("api/categories")]
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryViewModel saveViewModel)
        {
            var category = await _mediator.Send(new CreateOrUpdateCategoryCommand 
            { 
                UserId = User.Identity.UserId(),
                Name = saveViewModel.Name
            });

            return Ok(_mapper.Map<CategoryViewModel>(category));
        }

        [Route("api/categories")]
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryViewModel updateViewModel)
        {
            var category = await _mediator.Send(new CreateOrUpdateCategoryCommand
            {
                UserId = User.Identity.UserId(),
                Name = updateViewModel.Name,
                Id = updateViewModel.Id
            });

            return Ok(_mapper.Map<CategoryViewModel>(category));
        }

        [Route("api/categories/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _mediator.Send(new DeleteCategoryCommand { CategoryId = id });

            return Ok();
        }
    }
}