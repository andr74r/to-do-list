using System.Collections.Generic;
using System.Linq;

namespace ToDoList.Issue.Domain.Entities
{
    public class Category
    {
        private int? _id;
        public int? Id
        {
            get
            {
                return _id;
            }
        }

        public int UserId { get; private set; }

        public string Name { get; private set; }

        public IReadOnlyCollection<Issue> GetIssues() => _issues.AsReadOnly();

        private List<Issue> _issues;

        public Category(int userId, string name)
        {
            if (userId <= 0)
            {
                throw new System.ArgumentException("UserId should be greater than 0");
            }

            ThrowExceptionIfNameIsInvalid(name);

            UserId = userId;
            Name = name;
            _issues = new List<Issue>();
        }

        public Category(int userId, string name, List<Issue> issues)
            : this(userId, name)
        {
            if (issues == null)
            {
                throw new System.ArgumentException("Issues cannot be null");
            }

            _issues = issues;
        }

        public Category(int? id, int userId, string name, List<Issue> issues)
            : this(userId, name, issues)
        {
            _id = id;
        }

        public void SetName(string name)
        {
            ThrowExceptionIfNameIsInvalid(name);

            Name = name;
        }

        public Issue AddIssue(string issueName)
        {
            if (_issues.Any(x => x.Name == issueName))
            {
                throw new System.ArgumentException("Issue with the same name already exists");
            }

            var issue = new Issue(issueName);

            _issues.Add(issue);

            return issue;
        }

        public void RemoveIssue(string issueName)
        {
            _issues.RemoveAll(x => x.Name == issueName);
        }

        public Issue ChangeIssueName(string oldName, string newName)
        {
            var issue = _issues.SingleOrDefault(x => x.Name == oldName);

            if (issue == null)
            {
                throw new System.ArgumentException("Issue does not exist in this category");
            }

            if (_issues.Any(x => x.Name == newName))
            {
                throw new System.ArgumentException("Issue with the same name already exists");
            }

            issue.SetName(newName);

            return issue;
        }

        public Issue ChangeIssueStatus(string issueName)
        {
            var issue = _issues.Single(x => x.Name == issueName);

            issue.ChangeStatus();

            return issue;
        }

        public Category Clone()
        {
            return new Category(Id, UserId, Name, _issues.Select(x => x.Clone()).ToList());
        }

        private void ThrowExceptionIfNameIsInvalid(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new System.ArgumentException("Category name is invalid");
            }
        }
    }
}
