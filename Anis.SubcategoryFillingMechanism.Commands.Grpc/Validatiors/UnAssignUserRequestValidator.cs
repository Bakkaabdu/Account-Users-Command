using Anis.SubcategoryFillingMechanism.Commands.Grpc.Protos;
using FluentValidation;

namespace Anis.SubcategoryFillingMechanism.Commands.Grpc.Validators
{
    public class UnAssignUserRequestValidator : AbstractValidator<UnAssignUserRequest>
    {
        public UnAssignUserRequestValidator()
        {
            RuleFor(request => request.AccountId)
                .Must(BeAValidGuid).WithMessage("AccountId must be a valid GUID.")
                .NotEqual(Guid.Empty.ToString()).WithMessage("AccountId cannot be an empty GUID.");

            RuleFor(request => request.UserId)
                .Must(BeAValidGuid).WithMessage("UserId must be a valid GUID.")
                .NotEqual(Guid.Empty.ToString()).WithMessage("UserId cannot be an empty GUID.");
        }

        private bool BeAValidGuid(string id)
        {
            return Guid.TryParse(id, out _);
        }
    }
}