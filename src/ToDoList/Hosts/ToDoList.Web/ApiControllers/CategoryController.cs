using Microsoft.AspNetCore.Mvc;
using ToDoList.Web.ViewModels;
using System.Collections.Generic;

namespace ToDoList.Web.ApiControllers
{
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [Route("api/categories")]
        [HttpGet]
        public IActionResult GetCategories()
        {
            var viewModel = new List<CategoryViewModel>
            {
                new CategoryViewModel
                {
                    Id = 1,
                    Name = "home"
                },
                new CategoryViewModel
                {
                    Id = 2,
                    Name = "work"
                }
            };

            return Ok(viewModel);
        }
    }
}