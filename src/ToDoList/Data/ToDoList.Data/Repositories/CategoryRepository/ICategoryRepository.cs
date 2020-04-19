using System.Collections.Generic;
using ToDoList.Data.Entities;

namespace ToDoList.Data.Repositories.CategoryRepository
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetUserCategories(int userId);

        void SaveCategory(Category category);

        void DeleteCategory(int id);
    }
}
