using Anis.SubcategoryFillingMechanism.Commands.Domain.Exceptions.Abstraction.Exceptions;
using Anis.SubcategoryFillingMechanism.Commands.Domain.Resources;


namespace Anis.SubcategoryFillingMechanism.Commands.Domain.Exceptions
{
    public class SubcategoryFillingMechanismAlreadyAddedException : Exception, IProblemDetailsProvider
    {
        public ServiceProblemDetails GetProblemDetails()
            => new()
            {
                Title = Phrases.SubcategoryFillingMechanismAlreadyAdded, // from .resx file
                Type = "subcategory-filling-mechanism-already-added",
                StatusCode = ExceptionStatusCode.AlreadyExists
            };

    }
}
