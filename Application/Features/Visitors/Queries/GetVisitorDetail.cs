using Application.Contracts.Persistence;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Visitors.Queries
{
    public static class GetVisitorDetail
    {
        public record Query(int Id) : IRequest<VisitorDto>;

        public class Handler : IRequestHandler<Query, VisitorDto>
        {
            private readonly IAsyncRepository<Visitor> _visitorRepository;
            private readonly IMapper _mapper;

            public Handler(IMapper mapper, IAsyncRepository<Visitor> visitorRepository)
            {
                _mapper = mapper;
                _visitorRepository = visitorRepository;
            }

            public async Task<VisitorDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var visitor = await _visitorRepository.GetByIdAsync(request.Id);

                return _mapper.Map<VisitorDto>(visitor);
            }
        }
    }
}