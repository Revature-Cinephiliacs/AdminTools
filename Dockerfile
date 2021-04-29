FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["AdminToolAPI/AdminToolAPI.csproj", "AdminToolAPI/"]
RUN dotnet restore "AdminToolAPI/AdminToolAPI.csproj"
COPY . .
WORKDIR "/src/AdminToolAPI"
RUN dotnet build "AdminToolAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AdminToolAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AdminToolAPI.dll"]
