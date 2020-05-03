using FluentValidation;
using ToDoList.Common;
using ToDoList.Security.Data.Entities;

namespace ToDoList.Security.Core.Validators
{
    internal class UserValidator : AbstractValidator<User>, IEntityValidator<User>
    {
        private const string PhoneTemplate = @"^[0-9\-\+]{9,15}$";

        public UserValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Phone)
                .NotEmpty()
                .Matches(PhoneTemplate);

            RuleFor(x => x.PasswordHash)
                .NotEmpty();
        }

        public bool IsValid(User user)
        {
            return this.Validate(user).IsValid;
        }
    }
}
