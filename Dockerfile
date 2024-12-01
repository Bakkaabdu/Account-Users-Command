#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Anis.SubcategoryFillingMechanism.Commands.Grpc/Anis.SubcategoryFillingMechanism.Commands.Grpc.csproj", "Anis.SubcategoryFillingMechanism.Commands.Grpc/"]
COPY ["Anis.SubcategoryFillingMechanism.Commands.Infra/Anis.SubcategoryFillingMechanism.Commands.Infra.csproj", "Anis.SubcategoryFillingMechanism.Commands.Infra/"]
COPY ["Anis.SubcategoryFillingMechanism.Commands.Application/Anis.SubcategoryFillingMechanism.Commands.Application.csproj", "Anis.SubcategoryFillingMechanism.Commands.Application/"]
COPY ["Anis.SubcategoryFillingMechanism.Commands.Domain/Anis.SubcategoryFillingMechanism.Commands.Domain.csproj", "Anis.SubcategoryFillingMechanism.Commands.Domain/"]
RUN dotnet restore "./Anis.SubcategoryFillingMechanism.Commands.Grpc/Anis.SubcategoryFillingMechanism.Commands.Grpc.csproj"
COPY . .
WORKDIR "/src/Anis.SubcategoryFillingMechanism.Commands.Grpc"
RUN dotnet build "./Anis.SubcategoryFillingMechanism.Commands.Grpc.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Anis.SubcategoryFillingMechanism.Commands.Grpc.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Anis.SubcategoryFillingMechanism.Commands.Grpc.dll"]