# Dockerfile - SIMPLIFIED APPROACH (z debugowaniem)
# Etap budowania
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src/A03_Injection_CSRF_Antiforgery/ 
COPY ./A03_Injection_CSRF_Antiforgery/ ./
RUN dotnet restore
RUN dotnet publish -c Release -o /app

# Etap runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app .

# DODAJ TĘ LINIĘ TYMCZASOWO, ABY ZOBACZYĆ ZAWARTOŚĆ KATALOGU /app
CMD ["ls", "-l", "/app"]

# ZAKOMENTUJ LUB USUNIJ PONIŻSZE LINIĘ ENTRYPOINT NA CZAS DEBUGOWANIA
ENTRYPOINT ["dotnet", "A03_Injection_CSRF_Antiforgery.dll"]


EXPOSE 8080