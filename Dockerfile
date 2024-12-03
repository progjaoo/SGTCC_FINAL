# Use the official ASP.NET base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Use the SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["SistemaGestaoTCC.Application/SistemaGestaoTCC.Application.csproj", "./SistemaGestaoTCC.Application/"]
COPY ["SistemaGestaoTCC.Core/SistemaGestaoTCC.Core.csproj", "./SistemaGestaoTCC.Core/"]
COPY ["SistemaGestaoTCC.Infrastructure/SistemaGestaoTCC.Infrastructure.csproj", "./SistemaGestaoTCC.Infrastructure/"]
COPY ["SistemaGestaoTCC.API/SistemaGestaoTCC.API.csproj", "./SistemaGestaoTCC.API/"]

RUN dotnet restore "./SistemaGestaoTCC.Application/SistemaGestaoTCC.Application.csproj"
RUN dotnet restore "./SistemaGestaoTCC.Core/SistemaGestaoTCC.Core.csproj"
RUN dotnet restore "./SistemaGestaoTCC.Infrastructure/SistemaGestaoTCC.Infrastructure.csproj"
RUN dotnet restore "./SistemaGestaoTCC.API/SistemaGestaoTCC.API.csproj"

COPY . .

WORKDIR "/src/SistemaGestaoTCC.API"
RUN dotnet build "SistemaGestaoTCC.API.csproj" -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "SistemaGestaoTCC.API.csproj" -c Release -o /app/publish

# Final stage to run the application
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SistemaGestaoTCC.API.dll"]
