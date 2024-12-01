using Anis.AccountUsers.Commands.Grpc.Interceptors;
using Anis.SubcategoryFillingMechanism.Commands.Application;
using Anis.SubcategoryFillingMechanism.Commands.Grpc.ExceptionHandler;
using Anis.SubcategoryFillingMechanism.Commands.Grpc.Services;
using Anis.SubcategoryFillingMechanism.Commands.Grpc.Validatiors.Main;
using Anis.SubcategoryFillingMechanism.Commands.Infra;
using Anis.SubcategoryFillingMechanism.Commands.Infra.Persistence;
using Anis.SubcategoryFillingMechanism.Commands.Infra.Services.Logger;
using Calzolari.Grpc.AspNetCore.Validation;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Reflection;

namespace Anis.SubcategoryFillingMechanism.Commands.Grpc
{
    public partial class Program
    {
        private static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            Log.Logger = LoggerServiceBuilder.Build();

            //  Add services to the container.
            builder.Services.AddApplicationServices();

            builder.Services.AddInfraServices(builder.Configuration);

            builder.Services.AddGrpc(option =>
            {
                option.Interceptors.Add<ThreadCultureInterceptor>();

                option.EnableMessageValidation();

                option.Interceptors.Add<ApplicationExceptionInterceptor>();
            });

            builder.Services.AddAppValidators();

            builder.Host.UseSerilog();

            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<ApplicationDbContext>();
                context.Database.Migrate();
            }

            // Configure the HTTP request pipeline.

            app.MapGrpcService<ManageUsersServices>();
            app.MapGrpcService<SubcategoryFillingMechanismEventsHistoryServices>();
            app.MapGrpcService<SubcategoryFillingMechanismDemoServices>();
            app.MapGrpcService<SubcategoryFillingMechanismService>();
            app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

            app.Run();
        }
    }
}