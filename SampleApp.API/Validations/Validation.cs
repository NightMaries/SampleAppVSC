using FluentValidation;
using SampleApp.API.Dto;
using SampleApp.API.Entities;

namespace SampleApp.API.Validaions
{
    public class FluentValidator : AbstractValidator<User>
    {
        public FluentValidator()
        {
            RuleFor(u => u.Login).Must(StartsWithCapitalLetter)
                .WithMessage("Логин пользователя должно начинаться с заглавной буквы");
        }

        private bool StartsWithCapitalLetter(string username)
        {
            return char.IsLower(username[0]);
        }
    }
}