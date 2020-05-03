using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using ToDoList.Common.Validators;
using ToDoList.Issue.Core.Dto;
using ToDoList.Issue.Data.Repositories;

namespace ToDoList.Issue.Core.Services.Category
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly IEntityValidator<Data.Entities.Category> _validator;

        public CategoryService(
            ICategoryRepository categoryRepository,
            IMapper mapper,
            IEntityValidator<Data.Entities.Category> validator)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public CategoryDto CreateCategory(string name, int userId)
        {
            var category = new Data.Entities.Category
            {
                UserId = userId,
                Name = name
            };

            if (!_validator.IsValid(category))
            {
                throw new ArgumentException("Category is invalid");
            }

            _categoryRepository.SaveCategory(category);

            return _mapper.Map<CategoryDto>(category);
        }

        public void DeleteCategory(int id)
        {
            _categoryRepository.DeleteCategory(id);
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
