using Anis.SubcategoryFillingMechanism.Commands.Grpc.Extensions;
using Anis.SubcategoryFillingMechanism.Commands.Grpc.Protos;
using Grpc.Core;
using MediatR;

namespace Anis.SubcategoryFillingMechanism.Commands.Grpc.Services
{
    public class ManageUsersServices : Protos.ManageUsersCommand.ManageUsersCommandBase
    {
        private readonly IMediator _mediator;

        public ManageUsersServices(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override async Task<global::Anis.SubcategoryFillingMechanism.Commands.Grpc.Protos.Response> AssignUser(AssignUserRequest request, ServerCallContext context)
        {
            var command = request.ToCommand();

            await _mediator.Send(command);

            return new global::Anis.SubcategoryFillingMechanism.Commands.Grpc.Protos.Response
            {
                Message = "Cool bruh User Assigned"
            };

        }

        public override async Task<global::Anis.SubcategoryFillingMechanism.Commands.Grpc.Protos.Response> UnAssignUser(UnAssignUserRequest request, ServerCallContext context)
        {
            var command = request.ToCommand();

            await _mediator.Send(command);


            return new global::Anis.SubcategoryFillingMechanism.Commands.Grpc.Protos.Response
            {
                Message = "dammit bruh User UnAssigned"
            };

        }
    }
}
