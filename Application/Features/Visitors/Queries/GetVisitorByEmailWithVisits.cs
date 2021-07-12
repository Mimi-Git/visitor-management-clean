using Application.Contracts.Persistence;
using Application.Features.Visitors.Dtos;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Visitors.Queries
{
    public static class GetVisitorByEmailWithVisits
    {
        public record Query(string Email) : IRequest<VisitorWithVisitsDto>;

        public class Handler : IRequestHandler<Query, VisitorWithVisitsDto>
        {
            private readonly IVisitorRepository _visitorRepository;
            private readonly IMapper _mapper;

            public Handler(IMapper mapper, IVisitorRepository visitorRepository)
            {
                _mapper = mapper;
                _visitorRepository = visitorRepository;
            }

            public async Task<VisitorWithVisitsDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var visitor = await _visitorRepository.GetVisitorByEmailAsync(request.Email);
                // TODO : Verify if the visit are mapped |
                return _mapper.Map<VisitorWithVisitsDto>(visitor);
            }
        }
    }
}