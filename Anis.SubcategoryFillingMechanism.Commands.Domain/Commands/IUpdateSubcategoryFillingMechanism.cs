namespace Anis.SubcategoryFillingMechanism.Commands.Domain.Commands
{
    public interface IUpdateSubcategoryFillingMechanism
    {
        Guid SubcategoryId { get; }
        Guid UserId { get; }
        string SubcategoryInfo { get; }
        string EnglishSubcategoryInfo { get; }
        string FillingMechanism { get; }
        string EnglishFillingMechanism { get; }
    }
}
