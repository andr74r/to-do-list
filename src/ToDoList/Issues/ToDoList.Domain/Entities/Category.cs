using System.Collections.Generic;
using System.Linq;

namespace ToDoList.Issue.Domain.Entities
{
    public class Category
    {
        public int? Id { get; private set; }

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

        public void SetName(string name)
        {
            ThrowExceptionIfNameIsInvalid(name);

            Name = name;
        }

        public void AddIssue(string issueName)
        {
            if (_issues.Any(x => x.Name == issueName))
            {
                throw new System.ArgumentException("Issue with the same name already exists");
            }

            _issues.Add(new Issue(issueName));
        }

        public void RemoveIssue(string issueName)
        {
            _issues.RemoveAll(x => x.Name == issueName);
        }

        public void ChangeIssueName(string oldName, string newName)
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
