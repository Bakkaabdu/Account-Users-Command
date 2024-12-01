using FluentValidation;

namespace Anis.SubcategoryFillingMechanism.Commands.Grpc.Validatiors
{
    public class UpdateSubcategoryFillingMechanismVideoRequestValidator : AbstractValidator<UpdateSubcategoryFillingMechanismVideoRequest>
    {
        public UpdateSubcategoryFillingMechanismVideoRequestValidator()
        {
            RuleFor(r => r.SubcategoryId)
                .Must(subCategoryId => Guid.TryParse(subCategoryId, out _))
                .NotEqual(Guid.Empty.ToString());

            RuleFor(r => r.FillingMechanismVideoUrl)
                .NotEqual(string.Empty);
        }
    }
}


