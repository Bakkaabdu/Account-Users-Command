using Anis.SubcategoryFillingMechanism.Commands.Domain.Resources;
using Anis.SubcategoryFillingMechanism.Commands.Grpc.Extensions;
using Grpc.Core;
using MediatR;
namespace Anis.SubcategoryFillingMechanism.Commands.Grpc.Services
{
    public class SubcategoryFillingMechanismService : SubcategoryFillingMechanismCommand.SubcategoryFillingMechanismCommandBase
    {
        private readonly IMediator _mediator;
        public SubcategoryFillingMechanismService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override async Task<Response> AddSubcategoryFillingMechanism(AddSubcategoryFillingMechanismRequest request, ServerCallContext context)
        {
            var claims = context.GetRequiredAccessClaims();

            var command = request.ToCommand(claims.User.Id);

            await _mediator.Send(command);

            return new Response
            {
                Message = Phrases.SubcategoryFillingMechanismAdded
            };
        }

        public override async Task<Response> UpdateSubcategoryFillingMechanism(UpdateSubcategoryFillingMechanismRequest request, ServerCallContext context)
        {
            var claims = context.GetRequiredAccessClaims();

            var command = request.ToCommand(claims.User.Id);

            await _mediator.Send(command);

            return new Response
            {
                Message = Phrases.SubcategoryFillingMechanismUpdated,
            };
        }

        public override async Task<Response> UpdateSubcategoryFillingMechanismVideo(UpdateSubcategoryFillingMechanismVideoRequest request, ServerCallContext context)
        {
            var claims = context.GetRequiredAccessClaims();

            var command = request.ToCommand(claims.User.Id);

            await _mediator.Send(command);

            return new Response
            {
                Message = Phrases.SubcategoryFillingMechanismVideoUpdated
            };
        }

        public override async Task<Response> DeleteSubcategoryFillingMechanismVideo(DeleteSubcategoryFillingMechanismVideoRequest request, ServerCallContext context)
        {
            var claims = context.GetRequiredAccessClaims();

            var command = request.ToCommand(claims.User.Id);

            await _mediator.Send(command);

            return new Response
            {
                Message = Phrases.VideoUrlDeleted
            };
        }

        public override async Task<Response> DeleteSubcategoryFillingMechanism(DeleteSubcategoryFillingMechanismRequest request, ServerCallContext context)
        {
            var claims = context.GetRequiredAccessClaims();

            var command = request.ToCommand(claims.User.Id);

            await _mediator.Send(command);

            return new Response
            {
                Message = Phrases.SubcategoryFillingMechanismDeleted
            };
        }
    }
}
