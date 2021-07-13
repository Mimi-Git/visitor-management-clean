using Application.Contracts.Persistence;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Visitors.Commands.CreateVisitor
{
    public class CreateVisitorCommandHandler : IRequestHandler<CreateVisitorCommand, CreateVisitorCommandResponse>
    {
        private readonly IAsyncRepository<Visitor> _visitorRepository;
        private readonly IMapper _mapper;

        public CreateVisitorCommandHandler(IMapper mapper, IAsyncRepository<Visitor> visitorRepository)
        {
            _mapper = mapper;
            _visitorRepository = visitorRepository;
        }

        public async Task<CreateVisitorCommandResponse> Handle(CreateVisitorCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateVisitorCommandResponse();

            var validator = new CreateVisitorCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                response.Success = false;
                response.ValidationErrors = new List<string>();

                foreach (var error in validationResult.Errors)
                {
                    response.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            if (response.Success)
            {
                var command = _mapper.Map<Visitor>(request);
                command = await _visitorRepository.CreateAsync(command);
                response.Visitor = _mapper.Map<VisitorDto>(command);
            }

            return response;
        }
    }
}