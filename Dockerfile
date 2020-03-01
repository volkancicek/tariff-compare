FROM mcr.microsoft.com/dotnet/core/runtime:3.1 AS base
WORKDIR /app
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
COPY . .
WORKDIR ./src
RUN dotnet restore TariffCompare/TariffCompare.csproj
WORKDIR /src/TariffCompare
RUN dotnet build TariffCompare.csproj -c Release -o /app
FROM build AS publish
RUN dotnet publish TariffCompare.csproj -c Release -o /app
FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TariffCompare.dll"]

