using FluentValidation;

namespace Anis.SubcategoryFillingMechanism.Commands.Grpc.Validatiors
{
    public class CatgoryUpdateSubcategoryFillingMechanismVideoVailidtor : AbstractValidator<UpdateSubcategoryFillingMechanismVideoRequest>
    {
        public CatgoryUpdateSubcategoryFillingMechanismVideoVailidtor()
        {

            RuleFor(r => r.SubcategoryId)
                .Must(subcategory => Guid.TryParse(subcategory, out _))
                .NotEqual(Guid.Empty.ToString());

            RuleFor(r => r.FillingMechanismVideoUrl)
                .NotEqual(string.Empty.ToString());

        }
    }
}
