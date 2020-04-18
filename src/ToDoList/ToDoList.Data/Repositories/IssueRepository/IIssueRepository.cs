using System.Collections.Generic;
using ToDoList.Data.Entities;

namespace ToDoList.Data.Repositories.IssueRepository
{
    public interface IIssueRepository
    {
        IEnumerable<Issue> GetIssuesByCategory(int categoryId);

        void SaveIssue(Issue issue);

        void DeleteIssue(int id);
    }
}
