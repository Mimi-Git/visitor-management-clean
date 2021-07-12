using Application.Contracts.Persistence;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Visits.Queries
{
    public static class GetVisitsList
    {
        public record Query() : IRequest<List<VisitDto>>;

        public class Handler : IRequestHandler<Query, List<VisitDto>>
        {
            private readonly IAsyncRepository<Visit> _visitsRepository;
            private readonly IMapper _mapper;

            public Handler(IMapper mapper, IAsyncRepository<Visit> visitsRepository)
            {
                _mapper = mapper;
                _visitsRepository = visitsRepository;
            }

            public async Task<List<VisitDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var visitsList = (await _visitsRepository.GetAllAsync()).OrderBy(v => v.ArrivalTime);

                return _mapper.Map<List<VisitDto>>(visitsList);
            }
        }
    }
}