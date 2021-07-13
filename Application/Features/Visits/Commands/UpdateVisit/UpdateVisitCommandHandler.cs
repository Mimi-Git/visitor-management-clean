using Application.Contracts.Persistence;
using Application.Exceptions;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Visits.Commands.UpdateVisit
{
    public class UpdateVisitCommandHandler : IRequestHandler<UpdateVisitCommand>
    {
        private readonly IAsyncRepository<Visit> _visitRepository;
        private readonly IMapper _mapper;

        public UpdateVisitCommandHandler(IMapper mapper, IAsyncRepository<Visit> visitRepository)
        {
            _mapper = mapper;
            _visitRepository = visitRepository;
        }

        public async Task<Unit> Handle(UpdateVisitCommand request, CancellationToken cancellationToken)
        {
            var visitToUpdate = await _visitRepository.GetByIdAsync(request.Id);

            if (visitToUpdate == null)
                throw new NotFoundException(nameof(Visit), request.Id);

            var validator = new UpdateVisitCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, visitToUpdate, typeof(UpdateVisitCommand), typeof(Visit));

            await _visitRepository.UpdateAsync(visitToUpdate);

            return Unit.Value;
        }
    }
}