using MediatR;
using ToDoList.Issue.Core.Dto;

namespace ToDoList.Issue.Application.Commands
{
    public class CreateIssueCommand : IRequest<IssueDto>
    {
        public int CategoryId { get; set; }

        public string IssueName { get; set; }
    }
}
