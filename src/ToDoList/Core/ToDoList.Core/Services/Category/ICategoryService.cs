using System.Collections.Generic;
using ToDoList.Core.Dto;

namespace ToDoList.Core.Services.Category
{
    public interface ICategoryService
    {
        IEnumerable<CategoryDto> GetUserCategories(int userId);

        CategoryDto CreateCategory(string name, int userId);

        CategoryDto UpdateCategory(CategoryDto categoryDto);
    }
}
