using Autofac;
using ToDoList.Core.Services.Category;
using ToDoList.Core.Services.Issue;

namespace ToDoList.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = AutofacConfig.ConfigureContainer();

            using (var scope = container.BeginLifetimeScope())
            {
                var categoryService = scope.Resolve<ICategoryService>();
                var issueService = scope.Resolve<IIssueService>();

                var category1 = categoryService.CreateCategory("Category1", 1);
                var category2 = categoryService.CreateCategory("Category2", 1);
                var category3 = categoryService.CreateCategory("Category3", 1);

                var issue1 = issueService.CreateIssue("issue1", category1.Id);
                var issue2 = issueService.CreateIssue("issue2", category1.Id);
                var issue3 = issueService.CreateIssue("issue3", category1.Id);

                issueService.CompleteIssue(issue2.Id);
            }
        }
    }
}
