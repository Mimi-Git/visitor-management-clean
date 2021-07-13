using Application.Contracts.Persistence;
using Application.Exceptions;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Visitors.Commands.UpdateVisitor
{
    public class UpdateVisitorCommandHandler : IRequestHandler<UpdateVisitorCommand>
    {
        private readonly IAsyncRepository<Visitor> _visitorRepository;
        private readonly IMapper _mapper;

        public UpdateVisitorCommandHandler(IAsyncRepository<Visitor> visitorRepository, IMapper mapper)
        {
            _visitorRepository = visitorRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateVisitorCommand request, CancellationToken cancellationToken)
        {
            var visitorToUpdate = await _visitorRepository.GetByIdAsync(request.Id);

            if (visitorToUpdate == null)
                throw new NotFoundException(nameof(Visitor), request.Id);

            var validator = new UpdateVisitorCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, visitorToUpdate, typeof(UpdateVisitorCommand), typeof(Visitor));

            await _visitorRepository.UpdateAsync(visitorToUpdate);

            return Unit.Value;
        }
    }
}