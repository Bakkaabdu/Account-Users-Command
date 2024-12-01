using Anis.SubcategoryFillingMechanism.Commands.Grpc.Validators;
using Calzolari.Grpc.AspNetCore.Validation;

namespace Anis.SubcategoryFillingMechanism.Commands.Grpc.Validatiors.Main
{
    public static class ValidationContainer
    {
        public static IServiceCollection AddAppValidators(this IServiceCollection services)
        {
            services.AddGrpcValidation();
            services.AddScoped<GrpcValidator>();
            services.AddValidator<UpdateSubcategoryFillingMechanismRequestValidator>();
            services.AddValidator<DeleteSubcategoryFillingMechanismVideoRequestValidator>();
            services.AddValidator<AddSubcategoryFillingMechanismRequestValidator>();
            services.AddValidator<UpdateSubcategoryFillingMechanismVideoRequestValidator>();
            services.AddValidator<DeleteSubcategoryFillingMechanismRequestValidator>();
            services.AddValidator<CatgoryUpdateSubcategoryFillingMechanismVideoVailidtor>();

            services.AddValidator<AssignUserRequestValidator>();
            services.AddValidator<UnAssignUserRequestValidator>();



            return services;
        }
    }
}
