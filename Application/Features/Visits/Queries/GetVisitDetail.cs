using Application.Contracts.Persistence;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Visits.Queries
{
    public static class GetVisitDetail
    {
        public record Query(int Id) : IRequest<VisitDto>;

        public class Handler : IRequestHandler<Query, VisitDto>
        {
            private readonly IAsyncRepository<Visit> _visitRepository;
            private readonly IMapper _mapper;

            public Handler(IMapper mapper, IAsyncRepository<Visit> visitRepository)
            {
                _mapper = mapper;
                _visitRepository = visitRepository;
            }

            public async Task<VisitDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var visit = await _visitRepository.GetByIdAsync(request.Id);

                return _mapper.Map<VisitDto>(visit);
            }
        }
    }
}