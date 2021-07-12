using Application.Contracts.Persistence;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Visitors.Queries
{
    public static class GetVisitorsList
    {
        public record Query() : IRequest<List<VisitorDto>>;

        public class Handler : IRequestHandler<Query, List<VisitorDto>>
        {
            private readonly IAsyncRepository<Visitor> _visitorRepository;
            private readonly IMapper _mapper;

            public Handler(IMapper mapper, IAsyncRepository<Visitor> visitorRepository)
            {
                _mapper = mapper;
                _visitorRepository = visitorRepository;
            }

            public async Task<List<VisitorDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var visitorsList = (await _visitorRepository.GetAllAsync()).OrderBy(v => v.LastName);

                return _mapper.Map<List<VisitorDto>>(visitorsList);
            }
        }
    }
}