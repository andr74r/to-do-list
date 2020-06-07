using System.Collections.Generic;
using System.Linq;
using ToDoList.Issue.Domain.Entities;
using ToDoList.Issue.Domain.Repositories;

namespace ToDoList.Issue.Infrastructure.InMemory
{
    public class InMemoryCategoryRepository : ICategoryRepository
    {
        private readonly object _syncObj = new object();
        private static int _currentId = 0;
        private static int _currentIssueId = 0;

        public IEnumerable<Category> GetUserCategories(int userId)
        {
            return Context.Categories
                .Where(x => x.UserId == userId)
                .Select(x => x.Clone());
        }

        public Category GetCategory(int id)
        {
            return Context.Categories.SingleOrDefault(x => x.Id == id)?.Clone();
        }

        public void SaveCategory(Category category)
        {
            lock (_syncObj) 
            {
                var existingCategory = Context.Categories.FirstOrDefault(x => x.Id == category.Id);

                if (existingCategory == null)
                {
                    _currentId++;

                    category.SetId(_currentId);

                    UpdateIssuesId(category);

                    Context.Categories.Add(category.Clone());
                }
                else
                {
                    var index = Context.Categories.IndexOf(existingCategory);

                    UpdateIssuesId(category);

                    Context.Categories[index] = category.Clone();
                }
            }

            void UpdateIssuesId(Category category)
            {
                foreach (var issue in category.GetIssues())
                {
                    if (!issue.Id.HasValue)
                    {
                        _currentIssueId++;

                        issue.SetId(_currentIssueId);
                    }
                }
            }
        }

        public void DeleteCategory(int id)
        {
            lock (_syncObj)
            {
                Context.Categories.RemoveAll(x => x.Id == id);
            }
        }
    }
}
