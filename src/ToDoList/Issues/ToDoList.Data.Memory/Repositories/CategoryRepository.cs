using System.Collections.Generic;
using System.Linq;
using ToDoList.Issue.Data.Entities;
using ToDoList.Issue.Data.Repositories;

namespace ToDoList.Issue.Data.Memory.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly object _syncObj = new object();
        private static int _currentId = 0;

        public void DeleteCategory(int id)
        {
            lock (_syncObj)
            {
                Context.Categories.RemoveAll(x => x.Id == id);
            }
        }

        public IEnumerable<Category> GetUserCategories(int userId)
        {
            return Context.Categories.Where(x => x.UserId == userId);
        }

        public void SaveCategory(Category category)
        {
            lock (_syncObj) 
            {
                var existingCategory = Context.Categories.FirstOrDefault(x => x.Id == category.Id);

                if (existingCategory == null)
                {
                    _currentId++;

                    category.Id = _currentId;

                    Context.Categories.Add(category);
                }
                else
                {
                    existingCategory.Name = category.Name;
                }
            }
        }
    }
}
