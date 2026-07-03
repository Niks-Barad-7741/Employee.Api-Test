using Employee.Application.DTO;
using FluentValidation;

namespace Employee.Application.Validators
{
    public class LoginValidator : AbstractValidator<LoginDTO>
    {
        public LoginValidator() 
        {
            RuleFor(n => n.Email)
                .NotNull().WithMessage("Email cannot be null.")
                .NotEmpty().WithMessage("Email is required.")
                .Matches(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")
                .WithMessage("Email Must be mail");

            RuleFor(n => n.Password)
                .NotNull().WithMessage("Password cannot be null")
                .NotEmpty().WithMessage("Password is required")
                .MinimumLength(6)
                .MaximumLength(20);

        }

    }
}
