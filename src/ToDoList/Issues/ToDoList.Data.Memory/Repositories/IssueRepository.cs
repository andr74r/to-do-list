﻿using System.Collections.Generic;
using System.Linq;
using ToDoList.Issue.Data.Repositories;

namespace ToDoList.Issue.Data.Memory.Repositories
{
    public class IssueRepository : IIssueRepository
    {
        private readonly object _syncObj = new object();
        private static int _currentId = 0;

        public void DeleteIssue(int id)
        {
            lock (_syncObj)
            {
                Context.Issues.RemoveAll(x => x.Id == id);
            }
        }

        public Entities.Issue GetIssue(int issueId)
        {
            return Context.Issues.SingleOrDefault(x => x.Id == issueId);
        }

        public IEnumerable<Entities.Issue> GetIssuesByCategory(int categoryId)
        {
            return Context.Issues.Where(x => x.CategoryId == categoryId);
        }

        public void SaveIssue(Entities.Issue issue)
        {
            lock (_syncObj)
            {
                var existingIssue = Context.Issues.FirstOrDefault(x => x.Id == issue.Id);

                if (existingIssue == null)
                {
                    _currentId++;

                    issue.Id = _currentId;

                    Context.Issues.Add(issue);
                }
                else
                {
                    existingIssue.Name = issue.Name;
                    existingIssue.IsCompleted = issue.IsCompleted;
                }
            }
        }
    }
}
