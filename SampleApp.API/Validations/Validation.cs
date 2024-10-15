using FluentValidation;
using SampleApp.API.Entities;

namespace SampleApp.API.Validaions
{
    public class FluentValidator : AbstractValidator<User>
    {
        public FluentValidator()
        {
            RuleFor(u => u.Name).Must(StartsWithCapitalLetter)
                .WithMessage("Имяпользователя должно начинаться с заглавной буквы");
        }

        private bool StartsWithCapitalLetter(string username)
        {
            return char.IsUpper(username[0]);
        }
    }
}