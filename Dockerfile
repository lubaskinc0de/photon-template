# Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copy solution and project files
COPY Photon.sln .
COPY src/ ./src

# Restore dependencies
RUN dotnet restore "src/Photon.Web/Photon.Web.csproj"

# Publish stage
FROM build AS publish
WORKDIR "/app/src/Photon.Web"
RUN dotnet publish "Photon.Web.csproj" -c Release -o /app/publish

# Final stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
EXPOSE 8000
COPY --from=publish /app/publish/ .
ENTRYPOINT ["dotnet", "Photon.Web.dll"]
