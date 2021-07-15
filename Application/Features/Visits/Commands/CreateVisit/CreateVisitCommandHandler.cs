using Application.Contracts.Infrastructure;
using Application.Contracts.Persistence;
using Application.Models.Mail;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Visits.Commands.CreateVisit
{
    public class CreateVisitCommandHandler : IRequestHandler<CreateVisitCommand, CreateVisitCommandResponse>
    {
        private readonly IAsyncRepository<Visit> _visitRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public CreateVisitCommandHandler(IMapper mapper, IAsyncRepository<Visit> visitRepository, IEmailService emailService)
        {
            _mapper = mapper;
            _visitRepository = visitRepository;
            _emailService = emailService;
        }

        public async Task<CreateVisitCommandResponse> Handle(CreateVisitCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateVisitCommandResponse();

            var validator = new CreateVisitCommandValidator();
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
                var command = _mapper.Map<Visit>(request);
                command = await _visitRepository.CreateAsync(command);
                response.Visit = _mapper.Map<VisitDto>(command);

                var email = new Email() { To = "emilien.boinet@gmail.com", Body = $"A new visit was created : {request}", Subject = "A new visit was created" };

                try
                {
                    await _emailService.SendEmail(email);
                }
                catch (System.Exception)
                {
                    // Log later
                }
            }

            return response;
        }
    }
}