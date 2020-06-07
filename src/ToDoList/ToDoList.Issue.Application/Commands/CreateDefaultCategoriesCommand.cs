using MediatR;

namespace ToDoList.Issue.Application.Commands
{
    public class CreateDefaultCategoriesCommand : IRequest<bool>
    {
        public int UserId { get; set; }
    }
}
