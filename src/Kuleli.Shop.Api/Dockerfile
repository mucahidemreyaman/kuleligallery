#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Kuleli.Shop.Api/Kuleli.Shop.Api.csproj", "Kuleli.Shop.Api/"]
RUN dotnet restore "Kuleli.Shop.Api/Kuleli.Shop.Api.csproj"
COPY . .
WORKDIR "/src/Kuleli.Shop.Api"
RUN dotnet build "Kuleli.Shop.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Kuleli.Shop.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Kuleli.Shop.Api.dll"]