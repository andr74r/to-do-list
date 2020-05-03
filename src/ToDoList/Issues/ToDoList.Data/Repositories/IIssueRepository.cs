using System.Collections.Generic;

namespace ToDoList.Issue.Data.Repositories
{
    public interface IIssueRepository
    {
        Entities.Issue GetIssue(int issueId);

        IEnumerable<Entities.Issue> GetIssuesByCategory(int categoryId);

        void SaveIssue(Entities.Issue issue);

        void DeleteIssue(int id);
    }
}
