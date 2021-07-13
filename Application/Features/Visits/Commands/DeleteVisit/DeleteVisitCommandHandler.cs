using Application.Contracts.Persistence;
using Application.Exceptions;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Visits.Commands.DeleteVisit
{
    public class DeleteVisitCommandHandler : IRequestHandler<DeleteVisitCommand>
    {
        private readonly IAsyncRepository<Visit> _visitRepository;
        private readonly IMapper _mapper;

        public DeleteVisitCommandHandler(IMapper mapper, IAsyncRepository<Visit> visitRepository)
        {
            _mapper = mapper;
            _visitRepository = visitRepository;
        }

        public async Task<Unit> Handle(DeleteVisitCommand request, CancellationToken cancellationToken)
        {
            var visitToDelete = await _visitRepository.GetByIdAsync(request.Id);

            if (visitToDelete == null)
                throw new NotFoundException(nameof(Visit), request.Id);

            await _visitRepository.DeleteAsync(visitToDelete);

            return Unit.Value;
        }
    }
}