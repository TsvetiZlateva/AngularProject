using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Commands
{
    public class CreatePersonCommandValidator : AbstractValidator<CreatePersonCommand>
    {
        public CreatePersonCommandValidator()
        {
            RuleFor(p => p.FirstName)
                .NotEmpty().WithMessage("FirstName is required.")
                .NotNull()
                .MaximumLength(30).WithMessage("FirstName must not exceed 30 characters.");

            RuleFor(p => p.Surname)
                .NotEmpty().WithMessage("Surname is required.")
                .NotNull()
                .MaximumLength(30).WithMessage("Surname must not exceed 30 characters.");

            RuleFor(p => p.DateOfBirth)
                .NotEmpty().WithMessage("DateOfBirth is required.")
                .NotNull();

            RuleFor(p => p.Address)
                .NotEmpty().WithMessage("Address is required.")
                .NotNull()
                .MaximumLength(100).WithMessage("Address must not exceed 100 characters.");

            RuleFor(p => p.Phone)
                .NotEmpty().WithMessage("Phone is required.")
                .NotNull()
                .MaximumLength(30).WithMessage("Phone must not exceed 30 characters.");

            RuleFor(p => p.IBAN)
                .NotEmpty().WithMessage("IBAN is required.")
                .NotNull()
                .MaximumLength(30).WithMessage("IBAN must not exceed 30 characters.");
        }
    }
}
