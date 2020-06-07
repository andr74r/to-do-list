using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ToDoList.Issue.Domain.Repositories;

namespace ToDoList.Issue.Application.Commands
{
    public class DeleteIssueCommandHandler : IRequestHandler<DeleteIssueCommand, bool>
    {
        private readonly ICategoryRepository _categoryRepository;

        public DeleteIssueCommandHandler(
            ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<bool> Handle(DeleteIssueCommand request, CancellationToken cancellationToken)
        {
            var category = _categoryRepository.GetCategory(request.CategoryId);

            if (category == null)
            {
                throw new System.ArgumentException("Category Not Found");
            }

            category.RemoveIssue(request.IssueName);

            _categoryRepository.SaveCategory(category);

            return true;
        }
    }
}
