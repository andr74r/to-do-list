﻿using System.Collections.Generic;
using ToDoList.Core.Dto;

namespace ToDoList.Core.Services.Issue
{
    public interface IIssueService
    {
        IEnumerable<IssueDto> GetIssuesByCategoryId(int categoryId);

        IssueDto CreateIssue(string name, int categoryId);

        IssueDto ChangeIssueStatus(int id, bool status);

        void DeleteIssue(int id);
    }
}
