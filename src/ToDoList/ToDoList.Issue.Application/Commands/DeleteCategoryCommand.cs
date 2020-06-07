using MediatR;

namespace ToDoList.Issue.Application.Commands
{
    public class DeleteCategoryCommand : IRequest<bool>
    {
        public int CategoryId { get; set; }
    }
}
