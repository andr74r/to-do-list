using MediatR;
using ToDoList.Issue.Core.Dto;

namespace ToDoList.Issue.Application.Commands
{
    public class ChangeIssueStatusCommand : IRequest<IssueDto>
    {
        public int CategoryId { get; set; }

        public string IssueName { get; set; }
    }
}
