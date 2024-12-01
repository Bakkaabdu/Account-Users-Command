using Anis.SubcategoryFillingMechanism.Commands.Application.Features.Commands.AddSubcategoryFillingMechanism;
using Anis.SubcategoryFillingMechanism.Commands.Application.Features.Commands.AssignUser;
using Anis.SubcategoryFillingMechanism.Commands.Application.Features.Commands.DeleteSubcategoryFillingMechanism;
using Anis.SubcategoryFillingMechanism.Commands.Application.Features.Commands.DeleteSubcategoryFillingMechanismVideoCommand;
using Anis.SubcategoryFillingMechanism.Commands.Application.Features.Commands.UnAssignUser;
using Anis.SubcategoryFillingMechanism.Commands.Application.Features.Commands.UpdateSubcategoryFillingMechanism;
using Anis.SubcategoryFillingMechanism.Commands.Application.Features.Commands.UpdateSubcategoryFillingMechanismVideo;
using Anis.SubcategoryFillingMechanism.Commands.Grpc.Protos;

namespace Anis.SubcategoryFillingMechanism.Commands.Grpc.Extensions
{
    public static class CommandExtensions
    {



        public static UpdateSubcategoryFillingMechanismCommand ToCommand(this UpdateSubcategoryFillingMechanismRequest request, string userId)
        {
            return new UpdateSubcategoryFillingMechanismCommand(
                        SubcategoryId: Guid.Parse(request.SubcategoryId),
                        UserId: Guid.Parse(userId),
                        SubcategoryInfo: request.SubcategoryInfo,
                        request.EnglishSubcatgoryInfo,
                        FillingMechanism: request.FillingMechanism,
                        request.EnglishFillingMechanism);
        }
        public static DeleteSubcategoryFillingMechanismVideoCommand ToCommand(this DeleteSubcategoryFillingMechanismVideoRequest request, string userId)
        {
            return new DeleteSubcategoryFillingMechanismVideoCommand(
                        SubcategoryId: Guid.Parse(request.SubcategoryId),
                        UserId: Guid.Parse(userId));
        }
        public static UpdateSubcategoryFillingMechanismVideoCommand ToCommand(this UpdateSubcategoryFillingMechanismVideoRequest request, string userId)
           => new(
                 SubcategoryId: Guid.Parse(request.SubcategoryId),
                 UserId: Guid.Parse(userId),
                 FillingMechanismVideoUrl: request.FillingMechanismVideoUrl
               );

        public static AddCommand ToCommand(this AddSubcategoryFillingMechanismRequest request, string userId)
           => new(
               SubcategoryId: Guid.Parse(request.SubcategoryId),
               UserId: Guid.Parse(userId),
               SubcategoryInfo: request.SubcategoryInfo,
               EnglishSubcategoryInfo: request.EnglishSubcatgoryInfo,
               FillingMechanism: request.FillingMechanism,
               EnglishFillingMechanism: request.EnglishFillingMechanism,
               FillingMechanismVideoUrl: request.FillingMechanismVideoUrl);

        public static DeleteSubcategoryFillingMechanismCommand ToCommand(this DeleteSubcategoryFillingMechanismRequest request, string userId)
            => new(Guid.Parse(request.SubcategoryId), Guid.Parse(userId));


        public static AssignUserCommand ToCommand(this AssignUserRequest request)
            => new(
      Guid.Parse(request.AccountId),
      Guid.Parse(request.UserId));
        public static UnAssignUserCommand ToCommand(this UnAssignUserRequest request)
                     => new(
             Guid.Parse(request.AccountId),
             Guid.Parse(request.UserId));
    }

}
