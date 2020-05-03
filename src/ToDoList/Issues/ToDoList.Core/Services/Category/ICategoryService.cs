using System.Collections.Generic;
using ToDoList.Issue.Core.Dto;

namespace ToDoList.Issue.Core.Services.Category
{
    public interface ICategoryService
    {
        IEnumerable<CategoryDto> GetUserCategories(int userId);

        CategoryDto CreateCategory(string name, int userId);

        CategoryDto UpdateCategory(CategoryDto categoryDto);

        void DeleteCategory(int id);
    }
}
