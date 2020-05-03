using ToDoList.Common.Validators;

namespace ToDoList.Issue.Core.Validators
{
    internal class IssueValidator : IEntityValidator<Data.Entities.Issue>
    {
        public bool IsValid(Data.Entities.Issue entity)
        {
            return !string.IsNullOrWhiteSpace(entity.Name);
        }
    }
}
