using System.Collections.Generic;
using ToDoList.Issue.Domain.Entities;

namespace ToDoList.Issue.Domain.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetUserCategories(int userId);

        Category GetCategory(int id);

        void SaveCategory(Category category);

        void DeleteCategory(int id);
    }
}
