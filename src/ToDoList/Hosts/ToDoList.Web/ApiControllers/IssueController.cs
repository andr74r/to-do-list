using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Issue.Application.Commands;
using ToDoList.Web.ViewModels.Issue;

namespace ToDoList.Web.ApiControllers
{
    [Authorize]
    [ApiController]
    public class IssueController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public IssueController(
            IMediator mediator,
            IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [Route("api/issues")]
        [HttpPost]
        public async Task<IActionResult> CreateIssue(CreateIssueViewModel viewModel)
        {
            var issue = await _mediator.Send(new CreateIssueCommand
            {
                IssueName = viewModel.Name,
                CategoryId = viewModel.CategoryId
            });

            return Ok(_mapper.Map<IssueViewModel>(issue));
        }

        [Route("api/issues/changeStatus")]
        [HttpPatch]
        public async Task<IActionResult> ChangeIssueStatus(ChangeIssueStatusViewModel viewModel)
        {
            var issue = await _mediator.Send(new ChangeIssueStatusCommand
            {
                CategoryId = viewModel.CategoryId,
                IssueName = viewModel.IssueName
            });

            return Ok(_mapper.Map<IssueViewModel>(issue));
        }

        [Route("api/issues")]
        [HttpDelete]
        public async Task<IActionResult> DeleteIssue(int categoryId, string issueName)
        {
            await _mediator.Send(new DeleteIssueCommand
            {
                CategoryId = categoryId,
                IssueName = issueName
            });

            return Ok();
        }
    }
}