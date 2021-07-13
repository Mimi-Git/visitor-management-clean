using Application.Responses;

namespace Application.Features.Visitors.Commands.CreateVisitor
{
    public class CreateVisitorCommandResponse : BaseResponse
    {
        public CreateVisitorCommandResponse() : base()
        {
        }

        public VisitorDto Visitor { get; set; }
    }
}