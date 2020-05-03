using ToDoList.Issue.Core.Services.Category;
using ToDoList.Issue.Core.Services.Issue;

namespace ToDoList.Issue.Core.Services.DefaultCategoryCreator
{
    public class DefaultCategoryCreator : IDefaultCategoryCreator
    {
        private readonly ICategoryService _categoryService;
        private readonly IIssueService _issueService;

        public DefaultCategoryCreator(
            ICategoryService categoryService,
            IIssueService issueService)
        {
            _categoryService = categoryService;
            _issueService = issueService;
        }

        public void CreateDefaultCategories(int userId)
        {
            var category1 = _categoryService.CreateCategory("Category 1", userId);
            _issueService.CreateIssue("Task 1", category1.Id);
            _issueService.CreateIssue("Task 2", category1.Id);

            var category2 = _categoryService.CreateCategory("Category 2", userId);
            _issueService.CreateIssue("Task 1", category2.Id);
            _issueService.CreateIssue("Task 2", category2.Id);
        }
    }
}
