using System.Collections.Generic;
using ToDoList.Issue.Data.Entities;

namespace ToDoList.Issue.Data.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetUserCategories(int userId);

        void SaveCategory(Category category);

        void DeleteCategory(int id);
    }
}
