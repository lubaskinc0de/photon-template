FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

COPY src/Photon.Infrastructure/Photon.Infrastructure.csproj src/Photon.Infrastructure/
COPY src/Photon.Cli/Photon.Cli.csproj src/Photon.Cli/
COPY src/Photon.Application/Photon.Application.csproj src/Photon.Application/
COPY src/Photon.Domain/Photon.Domain.csproj src/Photon.Domain/

RUN dotnet restore src/Photon.Cli/Photon.Cli.csproj

COPY src/ ./src

WORKDIR /app/src/Photon.Cli
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Photon.Cli.dll"]
