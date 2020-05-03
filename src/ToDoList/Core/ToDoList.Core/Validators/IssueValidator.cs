using ToDoList.Common;
using ToDoList.Data.Entities;

namespace ToDoList.Core.Validators
{
    internal class IssueValidator : IEntityValidator<Issue>
    {
        public bool IsValid(Issue entity)
        {
            return !string.IsNullOrWhiteSpace(entity.Name);
        }
    }
}
