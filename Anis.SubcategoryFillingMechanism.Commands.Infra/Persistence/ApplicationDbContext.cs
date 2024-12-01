using Anis.SubcategoryFillingMechanism.Commands.Domain.Entities;
using Anis.SubcategoryFillingMechanism.Commands.Domain.Events;
using Anis.SubcategoryFillingMechanism.Commands.Domain.Events.DataTypes;
using Anis.SubcategoryFillingMechanism.Commands.Infra.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Anis.SubcategoryFillingMechanism.Commands.Infra.Persistence
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EventConfiguration());
            modelBuilder.ApplyConfiguration(new OutboxMessageConfiguration());
            modelBuilder.ApplyConfiguration(new GenericEventConfiguration<SubcategoryFillingMechanismUpdated, SubcategoryFillingMechanismUpdatedData>());
            modelBuilder.ApplyConfiguration(new GenericEventConfiguration<SubcategoryFillingMechanismDeleted, SubcategoryFillingMechanismDeletedData>());
            modelBuilder.ApplyConfiguration(new GenericEventConfiguration<SubcategoryFillingMechanismVideoDeleted, SubcategoryFillingMechanismVideoDeletedData>());
            modelBuilder.ApplyConfiguration(new GenericEventConfiguration<SubcategoryFillingMechanismAdded, SubcategoryFillingMechanismAddedData>());
            modelBuilder.ApplyConfiguration(new GenericEventConfiguration<SubcategoryFillingMechanismVideoUpdated, SubcategoryFillingMechanismVideoUpdatedData>());
            modelBuilder.ApplyConfiguration(new GenericEventConfiguration<UserAssigned, UserAssignedData>());
            modelBuilder.ApplyConfiguration(new GenericEventConfiguration<UserUnAssigned, UnAssignedUserData>());

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Event> Events { get; set; }

        public DbSet<OutboxMessage> OutboxMessages { get; set; }

    }
}
