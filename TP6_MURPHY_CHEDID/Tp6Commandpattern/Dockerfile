FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Tp6Commandpattern/Tp6Commandpattern.csproj", "Tp6Commandpattern/"]
RUN dotnet restore "Tp6Commandpattern/Tp6Commandpattern.csproj"
COPY . .
WORKDIR "/src/Tp6Commandpattern"
RUN dotnet build "Tp6Commandpattern.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Tp6Commandpattern.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Tp6Commandpattern.dll"]
