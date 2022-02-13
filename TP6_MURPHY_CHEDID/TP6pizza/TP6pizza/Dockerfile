FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["TP6pizza/TP6pizza.csproj", "TP6pizza/"]
RUN dotnet restore "TP6pizza/TP6pizza.csproj"
COPY . .
WORKDIR "/src/TP6pizza"
RUN dotnet build "TP6pizza.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TP6pizza.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TP6pizza.dll"]
