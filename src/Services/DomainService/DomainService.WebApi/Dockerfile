#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5000
ENV ASPNETCORE_URLS=http://*:5000

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/DomainService/DomainService.WebApi/DomainService.WebApi.csproj", "Services/DomainService/DomainService.WebApi/"]
RUN dotnet restore "Services/DomainService/DomainService.WebApi/DomainService.WebApi.csproj"
COPY . .
WORKDIR "/src/Services/DomainService/DomainService.WebApi"
RUN dotnet build "DomainService.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DomainService.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DomainService.WebApi.dll"]