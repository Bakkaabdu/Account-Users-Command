namespace Anis.SubcategoryFillingMechanism.Commands.Domain.Commands
{
    public interface IDeleteSubcategoryFillingMechanismCommand
    {
        Guid SubcategoryId { get; }
        Guid UserId { get; }
    }
}
