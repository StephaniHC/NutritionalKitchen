# Usa la imagen base de .NET 8.0 SDK para compilar la aplicación
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:5075
ENV ASPNETCORE_ENVIRONMENT=Development
EXPOSE 5075
 
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia los archivos de la solución y restaura las dependencias

COPY ["NutritionalKitchen.sln", "."]
COPY ["NutritionalKitchen.Domain/NutritionalKitchen.Domain.csproj", "NutritionalKitchen.Domain/"]
COPY ["NutritionalKitchen.Application/NutritionalKitchen.Application.csproj", "NutritionalKitchen.Application/"]
COPY ["NutritionalKitchen.Infrastructure/NutritionalKitchen.Infrastructure.csproj", "NutritionalKitchen.Infrastructure/"] 
COPY ["NutritionalKitchen.WebApi/NutritionalKitchen.WebApi.csproj", "NutritionalKitchen.WebApi/"]
COPY ["NutritionalKitchen.Integration/NutritionalKitchen.Integration.csproj", "NutritionalKitchen.Integration/"]
COPY ["NutritionalKitchen.WorkerService/NutritionalKitchen.WorkerService.csproj", "NutritionalKitchen.WorkerService/"]

# Restaura los paquetes NuGet
RUN dotnet restore "./NutritionalKitchen.WebApi/NutritionalKitchen.WebApi.csproj"
RUN dotnet restore "./NutritionalKitchen.WorkerService/NutritionalKitchen.WorkerService.csproj"																							 

# Copia todo el código fuente
COPY . . 
WORKDIR "/src/NutritionalKitchen.WebApi"
RUN dotnet build "NutritionalKitchen.WebApi.csproj" -c Release -o /app/build/webapi

WORKDIR "/src/NutritionalKitchen.WorkerService"
RUN dotnet build "NutritionalKitchen.WorkerService.csproj" -c Release -o /app/build/workerservice
 
FROM build AS publish
WORKDIR "/src/NutritionalKitchen.WebApi"
RUN dotnet publish "./NutritionalKitchen.WebApi.csproj" -c Release -o /app/publish/webapi /p:UseAppHost=false

FROM build AS publish-workerservice
WORKDIR "/src/NutritionalKitchen.WorkerService"
RUN dotnet publish "./NutritionalKitchen.WorkerService.csproj" -c Release -o /app/publish/workerservice /p:UseAppHost=false

# Crea la imagen final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish/webapi .
COPY --from=publish-workerservice /app/publish/workerservice .

# Crea el script de inicio
RUN echo '#!/bin/bash \n\
dotnet /app/NutritionalKitchen.WebApi.dll & \n\
dotnet /app/NutritionalKitchen.WorkerService.dll \n\
wait' > /app/entrypoint.sh && \
chmod +x /app/entrypoint.sh

ENTRYPOINT ["/bin/bash", "/app/entrypoint.sh"] 