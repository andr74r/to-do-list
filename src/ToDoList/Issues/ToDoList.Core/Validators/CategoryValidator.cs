using ToDoList.Common.Validators;
using ToDoList.Issue.Data.Entities;

namespace ToDoList.Issue.Core.Validators
{
    internal class CategoryValidator : IEntityValidator<Category>
    {
        public bool IsValid(Category entity)
        {
            return !string.IsNullOrWhiteSpace(entity.Name);
        }
    }
}
