using Anis.SubcategoryFillingMechanism.Commands.Domain.Commands;
using Anis.SubcategoryFillingMechanism.Commands.Domain.Events;
using Anis.SubcategoryFillingMechanism.Commands.Domain.Events.DataTypes;

namespace Anis.SubcategoryFillingMechanism.Commands.Domain.Extensions
{
    public static class EventExtensions
    {
        public static SubcategoryFillingMechanismAdded ToEvent(this IAddCommand command, int sequence = 1)
        {
            return new(
               aggregateId: command.SubcategoryId,
               userId: command.UserId.ToString(),
               sequence: sequence,
               data: new SubcategoryFillingMechanismAddedData(
                   command.SubcategoryInfo,
                   command.EnglishSubcategoryInfo,
                   command.FillingMechanism,
                   command.EnglishFillingMechanism,
                   command.FillingMechanismVideoUrl));
        }

        public static SubcategoryFillingMechanismUpdated ToEvent(this IUpdateSubcategoryFillingMechanism command, int sequence)
        {
            return new(
                aggregateId: command.SubcategoryId,
                userId: command.UserId.ToString(),
                sequence: sequence,
                data: new SubcategoryFillingMechanismUpdatedData(
                   command.SubcategoryInfo,
                   command.EnglishSubcategoryInfo,
                   command.FillingMechanism,
                   command.EnglishFillingMechanism)
                );
        }

        public static SubcategoryFillingMechanismDeleted ToEvent(this IDeleteSubcategoryFillingMechanismCommand command, int sequence)
        {
            return new(
                aggregateId: command.SubcategoryId,
                userId: command.UserId.ToString(),
                sequence: sequence,
                data: new SubcategoryFillingMechanismDeletedData()
                );
        }
        public static SubcategoryFillingMechanismVideoUpdated ToEvent(this IUpdateSubcategoryFillingMechanismVideo command, int sequence)
        {
            return new(
                aggregateId: command.SubcategoryId,
                userId: command.UserId.ToString(),
                sequence: sequence,
                data: new SubcategoryFillingMechanismVideoUpdatedData(
                                                                command.FillingMechanismVideoUrl)
                );
        }
        public static SubcategoryFillingMechanismVideoDeleted ToEvent(this IDeleteSubcategoryFillingMechanismVideo command, int sequence)
        {
            return new(
                aggregateId: command.SubcategoryId,
                userId: command.UserId.ToString(),
                sequence: sequence,
                data: new SubcategoryFillingMechanismVideoDeletedData()
                );
        }
        public static UserAssigned ToEvent(this IAssignUserCommand command, int sequence = 1)

           => new(
                aggregateId: command.AccountId,
                userId: command.UserId.ToString(),
                data: new UserAssignedData(command.UserId),
                sequence: sequence);

        public static UserUnAssigned ToEvent(this IUnAssignedUserCommand command, int sequence = 1)

           => new(
               aggregateId: command.AccountId,
               userId: command.UserId.ToString(),
               data: new UnAssignedUserData(command.UserId),
               sequence: sequence);

    }
}
