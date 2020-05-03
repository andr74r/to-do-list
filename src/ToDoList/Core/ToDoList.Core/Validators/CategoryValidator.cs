using ToDoList.Common;
using ToDoList.Data.Entities;

namespace ToDoList.Core.Validators
{
    internal class CategoryValidator : IEntityValidator<Category>
    {
        public bool IsValid(Category entity)
        {
            return !string.IsNullOrWhiteSpace(entity.Name);
        }
    }
}
