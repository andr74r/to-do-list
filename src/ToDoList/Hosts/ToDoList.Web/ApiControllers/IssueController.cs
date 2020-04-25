using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ToDoList.Core.Services.Issue;
using ToDoList.Web.ViewModels;

namespace ToDoList.Web.ApiControllers
{
    [ApiController]
    public class IssueController : ControllerBase
    {
        private readonly IIssueService _issueService;
        private readonly IMapper _mapper;

        public IssueController(
            IIssueService issueService,
            IMapper mapper)
        {
            _issueService = issueService;
            _mapper = mapper;
        }

        [Route("api/issues")]
        [HttpGet]
        public IActionResult GetIssues(int categoryId)
        {
            var issues = _issueService.GetIssuesByCategoryId(categoryId);

            var viewModel = issues
                .Select(x => _mapper.Map<IssueViewModel>(x))
                .ToList();

            return Ok(viewModel);
        }

        [Route("api/issues")]
        [HttpPost]
        public IActionResult CreateIssue(CreateIssueViewModel viewModel)
        {
            var issue = _issueService.CreateIssue(viewModel.Name, viewModel.CategoryId);

            return Ok(_mapper.Map<IssueViewModel>(issue));
        }

        [Route("api/issues/changeStatus")]
        [HttpPatch]
        public IActionResult ChangeIssueStatus(ChangeIssueStatusViewModel viewModel)
        {
            var issue = _issueService.ChangeIssueStatus(viewModel.Id, viewModel.IsCompleted);

            return Ok(_mapper.Map<IssueViewModel>(issue));
        }

        [Route("api/issues/{id}")]
        [HttpDelete]
        public IActionResult DeleteIssue(int id)
        {
            _issueService.DeleteIssue(id);

            return Ok();
        }
    }
}