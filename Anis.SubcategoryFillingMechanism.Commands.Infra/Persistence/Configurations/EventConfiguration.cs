
using Anis.SubcategoryFillingMechanism.Commands.Domain.Enums;
using Anis.SubcategoryFillingMechanism.Commands.Domain.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Anis.SubcategoryFillingMechanism.Commands.Infra.Persistence.Configurations
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.Property(e => e.Type)
                   .HasMaxLength(128)
                   .HasConversion<string>();

            builder.HasDiscriminator(e => e.Type)
                .HasValue<SubcategoryFillingMechanismUpdated>(EventType.SubcategoryFillingMechanismUpdated)
                .HasValue<SubcategoryFillingMechanismAdded>(EventType.SubcategoryFillingMechanismAdded)
                .HasValue<SubcategoryFillingMechanismDeleted>(EventType.SubcategoryFillingMechanismDeleted)
                .HasValue<SubcategoryFillingMechanismVideoDeleted>(EventType.SubcategoryFillingMechanismVideoDeleted)
                .HasValue<SubcategoryFillingMechanismVideoUpdated>(EventType.SubcategoryFillingMechanismVideoUpdated)
                .HasValue<UserAssigned>(EventType.UserAssigned)
                .HasValue<UserUnAssigned>(EventType.UserUnAssigned);
        }
    }
}
