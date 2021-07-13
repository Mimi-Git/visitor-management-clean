using FluentValidation;

namespace Application.Features.Visits.Commands.UpdateVisit
{
    public class UpdateVisitCommandValidator : AbstractValidator<UpdateVisitCommand>
    {
        public UpdateVisitCommandValidator()
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