using Application.Contracts.Persistence;
using Application.Exceptions;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Visitors.Commands.DeleteVisitor
{
    public class DeleteVisitorCommandHandler : IRequestHandler<DeleteVisitorCommand>
    {
        private readonly IAsyncRepository<Visitor> _visitorRepository;
        private readonly IMapper _mapper;

        public DeleteVisitorCommandHandler(IMapper mapper, IAsyncRepository<Visitor> visitorRepository)
        {
            _mapper = mapper;
            _visitorRepository = visitorRepository;
        }

        public async Task<Unit> Handle(DeleteVisitorCommand request, CancellationToken cancellationToken)
        {
            var visitorToDelete = await _visitorRepository.GetByIdAsync(request.Id);

            if (visitorToDelete == null)
                throw new NotFoundException(nameof(Visitor), request.Id);

            await _visitorRepository.DeleteAsync(visitorToDelete);

            return Unit.Value;
        }
    }
}