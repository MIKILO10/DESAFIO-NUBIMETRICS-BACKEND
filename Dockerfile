# Use the official .NET SDK image for build environment
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copy everything and restore as distinct layers
COPY . .

# Change the directory to the project folder
WORKDIR /app/DESAFIOS.NUBIMETRICS/DESAFIOS.NUBIMETRICS.Web.API

# Restore dependencies
RUN dotnet restore

# Build and publish the release version
RUN dotnet publish -c Release -o /app/out

# Use the official ASP.NET Core image for runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Copy the published files from the build environment
COPY --from=build-env /app/out .

# Expose the new port
EXPOSE 8081

# Specify the entry point to run your application
ENTRYPOINT ["dotnet", "Desafios.Nubimetrics.API.dll"]
