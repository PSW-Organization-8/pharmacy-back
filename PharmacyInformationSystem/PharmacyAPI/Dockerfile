FROM mcr.microsoft.com/dotnet/aspnet:5.0-focal AS base

RUN groupadd -g 999 appuser && \
    useradd -r -u 999 -g appuser appuser
USER appuser

WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-focal AS build
WORKDIR /src
COPY ["PharmacyAPI.csproj", "./"]
RUN dotnet restore "./PharmacyAPI.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "PharmacyAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PharmacyAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PharmacyAPI.dll"]