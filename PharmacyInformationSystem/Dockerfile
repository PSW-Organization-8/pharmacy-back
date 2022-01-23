FROM mcr.microsoft.com/dotnet/aspnet:5.0-focal AS base

RUN groupadd -g 5000 appuser && \
    useradd -u 5000 -g appuser appuser

USER appuser:appuser

WORKDIR /app
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:5.0-focal AS build
WORKDIR /src
COPY ["PharmacyAPI/PharmacyAPI.csproj", "PharmacyAPI/"]
COPY ["Pharmacy/PharmacyClassLib.csproj", "Pharmacy/"]
RUN dotnet restore "PharmacyAPI/PharmacyAPI.csproj"
COPY . .
WORKDIR "/src/PharmacyAPI"
RUN dotnet build "PharmacyAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PharmacyAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PharmacyAPI.dll"]