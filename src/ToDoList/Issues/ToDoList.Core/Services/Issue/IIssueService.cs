using System.Collections.Generic;
using ToDoList.Issue.Core.Dto;

namespace ToDoList.Issue.Core.Services.Issue
{
    public interface IIssueService
    {
        IEnumerable<IssueDto> GetIssuesByCategoryId(int categoryId);

        IssueDto CreateIssue(string name, int categoryId);

        IssueDto ChangeIssueStatus(int id, bool status);

        void DeleteIssue(int id);
    }
}
