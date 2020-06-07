using MediatR;
using ToDoList.Issue.Core.Dto;

namespace ToDoList.Issue.Application.Commands
{
    public class CreateOrUpdateCategoryCommand : IRequest<CategoryDto>
    {
        public int? Id { get; set; }

        public int UserId { get; set; }

        public string Name { get; set; }
    }
}
