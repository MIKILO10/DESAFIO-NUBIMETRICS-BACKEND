# Establece la imagen base para el entorno de construcción
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /DESAFIOS.NUBIMETRICS

# Copia todo el contenido del directorio actual al contenedor
COPY . /DESAFIOS.NUBIMETRICS/DESAFIOS.NUBIMETRICS.Web.API

# Restaura las dependencias de la aplicación
RUN dotnet restore

# Compila y publica la aplicación en modo Release
RUN dotnet publish -c Release -o out

# Establece la imagen base para el runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /App

# Copia los archivos publicados desde la fase de construcción
COPY --from=build-env /DESAFIOS.NUBIMETRICS/out .

# Especifica el comando de entrada para ejecutar la aplicación
ENTRYPOINT ["dotnet", "DotNet.Docker.dll"]
