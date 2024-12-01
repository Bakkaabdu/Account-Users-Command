using Anis.SubcategoryFillingMechanism.Commands.Domain.Commands;
using Anis.SubcategoryFillingMechanism.Commands.Domain.Events;
using Anis.SubcategoryFillingMechanism.Commands.Domain.Exceptions;
using Anis.SubcategoryFillingMechanism.Commands.Domain.Extensions;

namespace Anis.SubcategoryFillingMechanism.Commands.Domain.Models
{
    public class Subcategory : Aggregate<Subcategory>
    {

        public string SubcategoryInfo { get; private set; } = string.Empty;
        public string FillingMechanism { get; private set; } = string.Empty;
        public string? FillingMechanismVideoUrl { get; private set; }
        public bool Deleted { get; private set; }
        public static Subcategory Create(IAddCommand command)
        {
            Subcategory subcategory = new();

            var @event = command.ToEvent();

            subcategory.ApplyChange(@event);

            return subcategory;
        }

        public void ReCreate(IAddCommand command)
        {
            if (!Deleted)
                throw new SubcategoryFillingMechanismAlreadyAddedException();

            var @event = command.ToEvent(Sequence + 1);

            ApplyChange(@event);
        }

        public void Apply(SubcategoryFillingMechanismAdded @event)
        {
            SubcategoryInfo = @event.Data.SubcategoryInfo;
            FillingMechanism = @event.Data.FillingMechanism;
            FillingMechanismVideoUrl = @event.Data.FillingMechanismVideoUrl;
            Deleted = false;
        }


        public void UpdateSubcategoryFillingMechanism(IUpdateSubcategoryFillingMechanism command)
        {
            var @event = command.ToEvent(Sequence + 1);

            ApplyChange(@event);
        }
        public void Apply(SubcategoryFillingMechanismUpdated @event)
        {
            SubcategoryInfo = @event.Data.SubcategoryInfo;
            FillingMechanism = @event.Data.FillingMechanism;
        }

        public void Delete(IDeleteSubcategoryFillingMechanismCommand command)
        {
            if (Deleted)
                return;

            var @event = command.ToEvent(Sequence + 1);

            ApplyChange(@event);
        }

        public void Apply(SubcategoryFillingMechanismDeleted _)
        {
            Deleted = true;
        }
        public void DeleteSubcategoryFillingMechanismVideo(IDeleteSubcategoryFillingMechanismVideo command)
        {
            var @event = command.ToEvent(Sequence + 1);

            ApplyChange(@event);
        }
        public void Apply(SubcategoryFillingMechanismVideoDeleted _)
        {
            FillingMechanismVideoUrl = null;
        }

        public void UpdateSubcategoryFillingMechanismVideo(IUpdateSubcategoryFillingMechanismVideo command)
        {
            var @event = command.ToEvent(Sequence + 1);

            ApplyChange(@event);
        }
        public void Apply(SubcategoryFillingMechanismVideoUpdated @event)
        {
            FillingMechanismVideoUrl = @event.Data.FillingMechanismVideoUrl;
        }


    }
}
