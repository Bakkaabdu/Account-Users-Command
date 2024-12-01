using FluentValidation;

namespace Anis.SubcategoryFillingMechanism.Commands.Grpc.Validatiors
{
    public class DeleteSubcategoryFillingMechanismRequestValidator : AbstractValidator<DeleteSubcategoryFillingMechanismRequest>
    {
        public DeleteSubcategoryFillingMechanismRequestValidator()
        {
            RuleFor(r => r.SubcategoryId)
             .Must(subcategoryId => Guid.TryParse(subcategoryId, out _))
             .NotEqual(Guid.Empty.ToString());

        }
    }
}
