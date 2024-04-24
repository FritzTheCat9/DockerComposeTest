#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 5002
EXPOSE 5003

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["DockerComposeTest.Api2/DockerComposeTest.Api2.csproj", "DockerComposeTest.Api2/"]
RUN dotnet restore "./DockerComposeTest.Api2/DockerComposeTest.Api2.csproj"
COPY . .
WORKDIR "/src/DockerComposeTest.Api2"
RUN dotnet build "./DockerComposeTest.Api2.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./DockerComposeTest.Api2.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DockerComposeTest.Api2.dll"]