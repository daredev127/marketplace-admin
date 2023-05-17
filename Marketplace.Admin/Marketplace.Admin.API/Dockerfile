#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Marketplace.Admin.API/Marketplace.Admin.API.csproj", "Marketplace.Admin.API/"]
COPY ["Marketplace.Admin.Application/Marketplace.Admin.Application.csproj", "Marketplace.Admin.Application/"]
COPY ["Marketplace.Admin.Domain/Marketplace.Admin.Domain.csproj", "Marketplace.Admin.Domain/"]
COPY ["Marketplace.Admin.Infrastructure/Marketplace.Admin.Infrastructure.csproj", "Marketplace.Admin.Infrastructure/"]
RUN dotnet restore "Marketplace.Admin.API/Marketplace.Admin.API.csproj"
COPY . .
WORKDIR "/src/Marketplace.Admin.API"
RUN dotnet build "Marketplace.Admin.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Marketplace.Admin.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Marketplace.Admin.API.dll"]