using MediatR;

namespace ToDoList.Issue.Application.Commands
{
    public class DeleteIssueCommand : IRequest<bool>
    {
        public int CategoryId { get; set; }

        public string IssueName { get; set; }
    }
}
