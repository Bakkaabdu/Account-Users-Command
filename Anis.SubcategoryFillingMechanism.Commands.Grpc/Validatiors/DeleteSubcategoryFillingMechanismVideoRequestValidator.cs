using FluentValidation;

namespace Anis.SubcategoryFillingMechanism.Commands.Grpc.Validatiors
{
    public class DeleteSubcategoryFillingMechanismVideoRequestValidator : AbstractValidator<DeleteSubcategoryFillingMechanismVideoRequest>
    {
        public DeleteSubcategoryFillingMechanismVideoRequestValidator()
        {
            RuleFor(r => r.SubcategoryId)
                .Must(subCategoryId => Guid.TryParse(subCategoryId, out _))
                .NotEqual(Guid.Empty.ToString());

           
        }
    }
}