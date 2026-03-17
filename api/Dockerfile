FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/LogisticsLite.Api/LogisticsLite.Api.csproj", "src/LogisticsLite.Api/"]
COPY ["src/LogisticsLite.Data/LogisticsLite.Data.csproj", "src/LogisticsLite.Data/"]
RUN dotnet restore "src/LogisticsLite.Api/LogisticsLite.Api.csproj"
COPY . .
RUN dotnet build "src/LogisticsLite.Api/LogisticsLite.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "src/LogisticsLite.Api/LogisticsLite.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LogisticsLite.Api.dll"]
