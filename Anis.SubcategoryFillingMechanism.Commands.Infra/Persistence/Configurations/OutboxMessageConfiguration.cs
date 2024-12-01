using Anis.SubcategoryFillingMechanism.Commands.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Anis.SubcategoryFillingMechanism.Commands.Infra.Persistence.Configurations
{
    public class OutboxMessageConfiguration : IEntityTypeConfiguration<OutboxMessage>
    {
        public void Configure(EntityTypeBuilder<OutboxMessage> builder)
        {
            builder.HasOne(e => e.Event)
                .WithOne()
                .HasForeignKey<OutboxMessage>(e => e.Id)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
