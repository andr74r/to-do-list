using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using ToDoList.Core.Dto;
using ToDoList.Data.Repositories.CategoryRepository;

namespace ToDoList.Core.Services.Category
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(
            ICategoryRepository categoryRepository,
            IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public CategoryDto CreateCategory(string name, int userId)
        {
            var category = new Data.Entities.Category
            {
                UserId = userId,
                Name = name
            };

            _categoryRepository.SaveCategory(category);

            return _mapper.Map<CategoryDto>(category);
        }

        public IEnumerable<CategoryDto> GetUserCategories(int userId)
        {
            var categories = _categoryRepository.GetUserCategories(userId);

            return categories.Select(x => _mapper.Map<CategoryDto>(x));
        }

        public CategoryDto UpdateCategory(CategoryDto categoryDto)
        {
            var category = _mapper.Map<Data.Entities.Category>(categoryDto);

            _categoryRepository.SaveCategory(category);

            return _mapper.Map<CategoryDto>(category);
        }
    }
}
