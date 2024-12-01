using Anis.SubcategoryFillingMechanism.Commands.Application.Contracts.Repositories;
using Anis.SubcategoryFillingMechanism.Commands.Grpc.Extensions;
using Anis.SubcategoryFillingMechanism.Commands.Grpc.Protos.History;
using Azure;
using Grpc.Core;

namespace Anis.SubcategoryFillingMechanism.Commands.Grpc.Services
{
    public class SubcategoryFillingMechanismEventsHistoryServices : SubcategoryFillingMechanismEventsHistory.SubcategoryFillingMechanismEventsHistoryBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public SubcategoryFillingMechanismEventsHistoryServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public override async Task<Protos.History.Response> GetEvents(GetEventsRequest request, ServerCallContext context)
        {
            var events = await _unitOfWork.Events.GetAsPaginationAsync(request.CurrentPage, request.PageSize);

           var response = new Protos.History.Response();
            response.Events.ToOutputEvent(events);
            return response;
        }

    }
}
