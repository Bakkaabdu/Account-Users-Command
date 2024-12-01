using FluentValidation;

namespace Anis.SubcategoryFillingMechanism.Commands.Grpc.Validatiors
{
    public class AddSubcategoryFillingMechanismRequestValidator : AbstractValidator<AddSubcategoryFillingMechanismRequest>
    {
        public AddSubcategoryFillingMechanismRequestValidator()
        {
            RuleFor(r => r.SubcategoryId)
              .Must(subcategoryId => Guid.TryParse(subcategoryId, out _))
              .NotEqual(Guid.Empty.ToString());

            RuleFor(r => r.SubcategoryInfo)
                .NotEqual(string.Empty);

            RuleFor(r => r.FillingMechanism)
                .NotEqual(string.Empty);

            RuleFor(r => r.FillingMechanismVideoUrl)
                .NotEqual(string.Empty);
        }
    }
}
