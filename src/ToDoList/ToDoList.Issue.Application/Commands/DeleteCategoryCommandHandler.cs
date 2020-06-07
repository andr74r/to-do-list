using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using ToDoList.Issue.Domain.Repositories;

namespace ToDoList.Issue.Application.Commands
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, bool>
    {
        private readonly ICategoryRepository _categoryRepository;

        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            _categoryRepository.DeleteCategory(request.CategoryId);

            return true;
        }
    }
}
