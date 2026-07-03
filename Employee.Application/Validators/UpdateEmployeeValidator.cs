using Employee.Application.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Application.Validators
{
    public class UpdateEmployeeValidator : AbstractValidator<UpdateEmployeeDTO>
    {
        public UpdateEmployeeValidator() 
        {
            RuleFor(n => n.Name)
                .NotNull().WithMessage("Name Cannot Be Null")
                .NotEmpty().WithMessage("Name is required")
                .MinimumLength(3).WithMessage("Name at least 3 length")
                .MaximumLength(20)
                .Matches(@"^[A-za-z]+(?: [A-za-z]+)*$")
                .WithMessage("Name contains only letters and only one whitespace in the middle")
                .Matches(@"^\S(.*\S)?$")
                .WithMessage("Name Cannot be start and end with space");
            RuleFor(n => n.Email)
                .NotEmpty().WithMessage("Email is required")
                .NotNull().WithMessage("Email cannot be null")
                .Matches(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")
                .WithMessage("A valid email is required");
            RuleFor(n => n.Phone)
                .NotNull().WithMessage("Phone Cannot Be Null")
                .NotEmpty().WithMessage("Phone is required")
                .Matches(@"^[^-]+$").WithMessage("String Cannot contain negatie")
                .Matches(@"^\d{10}$")
                .MaximumLength(10);
            RuleFor(n => n.Department)
                .NotNull().WithMessage("department cannot be null")
                .NotEmpty().WithMessage("department is required")
                .MinimumLength(2)
                .MaximumLength(10)
                .Matches(@"^[A-za-z]").WithMessage("Department contains only letters")
                .Matches(@"^\S(.*\S)?$").WithMessage("Department cannot be whitespace");
            RuleFor(n => n.Salary)
                .GreaterThanOrEqualTo(0).WithMessage("Salary Cannot be negative")
                .NotNull().WithMessage("salary cannot be null")
                .NotEmpty().WithMessage("salary is requred");
        }
    }
}
