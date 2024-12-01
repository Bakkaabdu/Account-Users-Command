using Anis.SubcategoryFillingMechanism.Commands.Domain.Exceptions.Abstraction.Exceptions;
using Anis.SubcategoryFillingMechanism.Commands.Domain.Resources;

namespace Anis.SubcategoryFillingMechanism.Commands.Domain.Exceptions
{
    public class SubcategoryFillingMechanismHasNotBeenAddedException : Exception, IProblemDetailsProvider
    {
        public ServiceProblemDetails GetProblemDetails()
        => new()
        {
            Title = Phrases.SubcategoryFillingMechanismHasNotBeenAdded, // from .resx file                                                                 
            Type = "subcategory-filling-mechanism-has-not-added",
            StatusCode = ExceptionStatusCode.NotFound
        };
    }
}
