using MediatR;
using System.Collections.Generic;
using ToDoList.Issue.Core.Dto;

namespace ToDoList.Issue.Application.Queries
{
    public class GetCategoriesQuery : IRequest<List<CategoryDto>>
    {
        public int UserId { get; set; }
    }
}
