using Anis.SubcategoryFillingMechanism.Commands.Domain.Commands;
using Anis.SubcategoryFillingMechanism.Commands.Domain.Events;
using Anis.SubcategoryFillingMechanism.Commands.Domain.Extensions;
using Anis.SubcategoryFillingMechanism.Commands.Domain.Exceptions;
using Anis.SubcategoryFillingMechanism.Commands.Domain.Exceptions.Abstraction.Exceptions;
using Anis.SubcategoryFillingMechanism.Commands.Domain.Resources;
namespace Anis.SubcategoryFillingMechanism.Commands.Domain.Models
{
    public class Account : Aggregate<Account>
    {
        public List<Guid> Users { get; private set; } = new();

        public static Account Create(IAssignUserCommand command)
        {
            var account = new Account();

            var @event = command.ToEvent();

            account.ApplyChange(@event);

            return account;
        }

        public void AssignUser(IAssignUserCommand command)
        {
            if (Users.Contains(command.UserId))
                throw new AppException(ExceptionStatusCode.AlreadyExists, "User Already Exist");

            var @event = command.ToEvent(Sequence + 1);

            ApplyChange(@event);
        }

        public void UnAssignUser(IUnAssignedUserCommand command)
        {
            if (!Users.Contains(command.UserId))
                throw new AppException(ExceptionStatusCode.NotFound, "User Not Found");

            var @event = command.ToEvent(Sequence + 1);

            ApplyChange(@event);
        }

        public void Apply(UserAssigned @event)
        {
            Users.Add(@event.Data.UserId);
        }

        public void Apply(UserUnAssigned @event)
        {
            Users.Remove(@event.Data.UserId);
        }
    }
}


