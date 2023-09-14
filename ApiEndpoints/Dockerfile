FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ApiEndpoints/ApiEndpoints.csproj", "ApiEndpoints/"]
RUN dotnet restore "ApiEndpoints/ApiEndpoints.csproj"
COPY . .
WORKDIR "/src/ApiEndpoints"
RUN dotnet build "ApiEndpoints.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ApiEndpoints.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ApiEndpoints.dll"]
