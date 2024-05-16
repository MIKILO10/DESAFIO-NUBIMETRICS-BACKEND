# Establece la imagen base para el entorno de construcción
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copia todo el contenido del directorio actual al contenedor
COPY . . 

# Cambia el directorio de trabajo al directorio del proyecto
WORKDIR /app/DESAFIOS.NUBIMETRICS/DESAFIOS.NUBIMETRICS.Web.API

# Restaura las dependencias de la aplicación
RUN dotnet restore

# Compila y publica la aplicación en modo Release
RUN dotnet publish -c Release -o out

# Establece la imagen base para el runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Copia los archivos publicados desde la fase de construcción
COPY --from=build-env /app/DESAFIOS.NUBIMETRICS/DESAFIOS.NUBIMETRICS.Web.API/out .

# Especifica el comando de entrada para ejecutar la aplicación
ENTRYPOINT ["dotnet", "DotNet.Docker.dll"]
