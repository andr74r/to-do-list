using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ToDoList.Issue.Core.Dto;
using ToDoList.Issue.Domain.Repositories;

namespace ToDoList.Issue.Application.Queries
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, List<CategoryDto>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategoriesQueryHandler(
            ICategoryRepository categoryRepository,
            IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<List<CategoryDto>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = _categoryRepository.GetUserCategories(request.UserId);

            return categories.Select(x => _mapper.Map<CategoryDto>(x)).ToList();
        }
    }
}
