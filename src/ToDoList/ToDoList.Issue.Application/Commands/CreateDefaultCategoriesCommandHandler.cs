using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ToDoList.Issue.Domain.Entities;
using ToDoList.Issue.Domain.Repositories;

namespace ToDoList.Issue.Application.Commands
{
    public class CreateDefaultCategoriesCommandHandler : IRequestHandler<CreateDefaultCategoriesCommand, bool>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CreateDefaultCategoriesCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<bool> Handle(CreateDefaultCategoriesCommand request, CancellationToken cancellationToken)
        {
            var category1 = new Category(request.UserId, "Home");

            category1.AddIssue("Clean up room");
            category1.AddIssue("Fix tumbler switch");

            _categoryRepository.SaveCategory(category1);

            var category2 = new Category(request.UserId, "Work");

            category2.AddIssue("Set up CI/CD");
            category2.AddIssue("Create solution");

            _categoryRepository.SaveCategory(category2);

            return true;
        }
    }
}
