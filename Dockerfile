
FROM mcr.microsoft.com/dotnet/core/sdk:3.1-nanoserver-1903 AS build
WORKDIR /src
COPY ["CleaningBot.Web/CleaningBot.Web.csproj", "CleaningBot.Web/"]
RUN dotnet restore "CleaningBot.Web/CleaningBot.Web.csproj"
COPY . .
WORKDIR "/src/CleaningBot.Web"
RUN dotnet build "CleaningBot.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CleaningBot.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CleaningBot.Web.dll"]
