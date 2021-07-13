using FluentValidation;

namespace Application.Features.Visits.Commands.CreateVisit
{
    public class CreateVisitCommandValidator : AbstractValidator<CreateVisitCommand>
    {
        public CreateVisitCommandValidator()
        {
            RuleFor(v => v.ArrivalTime)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(v => v.DepartureTime)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(v => v.VisitorId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(v => v.EmployeeId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
        }
    }
}