using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ToDoList.Issue.Core.Dto;
using ToDoList.Issue.Domain.Entities;
using ToDoList.Issue.Domain.Repositories;

namespace ToDoList.Issue.Application.Commands
{
    public class CreateOrUpdateCategoryCommandHandler : IRequestHandler<CreateOrUpdateCategoryCommand, CategoryDto>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CreateOrUpdateCategoryCommandHandler(
            ICategoryRepository categoryRepository,
            IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CategoryDto> Handle(CreateOrUpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            Category category;

            if (request.Id.HasValue)
            {
                category = _categoryRepository.GetCategory(request.Id.Value);

                if (category == null)
                {
                    throw new System.ArgumentException($"Category with id = {request.Id} does not exist");
                }

                category.SetName(request.Name);

                _categoryRepository.SaveCategory(category);
            }
            else
            {
                category = new Category(request.UserId, request.Name);

                _categoryRepository.SaveCategory(category);
            }

            return _mapper.Map<CategoryDto>(category);
        }
    }
}
