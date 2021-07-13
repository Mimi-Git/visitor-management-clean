using Application.Responses;

namespace Application.Features.Visits.Commands.CreateVisit
{
    public class CreateVisitCommandResponse : BaseResponse
    {
        public CreateVisitCommandResponse() : base()
        {
        }

        public VisitDto Visit { get; set; }
    }
}