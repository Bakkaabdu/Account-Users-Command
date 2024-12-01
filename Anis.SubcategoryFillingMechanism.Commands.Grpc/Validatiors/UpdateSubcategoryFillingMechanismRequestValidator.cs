using Anis.SubcategoryFillingMechanism.Commands.Domain.Commands;
using FluentValidation;

namespace Anis.SubcategoryFillingMechanism.Commands.Grpc.Validatiors
{
    public class UpdateSubcategoryFillingMechanismRequestValidator : AbstractValidator<UpdateSubcategoryFillingMechanismRequest>
    {
        public UpdateSubcategoryFillingMechanismRequestValidator()
        {
            RuleFor(r => r.SubcategoryId)
                .Must(subCategoryId => Guid.TryParse(subCategoryId, out _))
                .NotEqual(Guid.Empty.ToString());

            RuleFor(r => r.SubcategoryInfo)
                .NotEqual(string.Empty);

            RuleFor(r => r.FillingMechanism)
                .NotEqual(string.Empty);
        }
    }
}

