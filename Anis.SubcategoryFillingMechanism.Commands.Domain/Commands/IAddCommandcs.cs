namespace Anis.SubcategoryFillingMechanism.Commands.Domain.Commands
{
    public interface IAddCommand
    {
        Guid SubcategoryId { get; }
        Guid UserId { get; }
        string SubcategoryInfo { get; }
        string EnglishSubcategoryInfo { get; }
        string FillingMechanism { get; }
        string EnglishFillingMechanism { get; }
        string? FillingMechanismVideoUrl { get; }
    }
}
