FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base 
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Cloud_Application_1/Cloud_Application_1.csproj", "Cloud_Application_1/"]
RUN dotnet restore "Cloud_Application_1/Cloud_Application_1.csproj"
COPY . .
WORKDIR "/src/Cloud_Application_1"
RUN dotnet build "Cloud_Application_1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Cloud_Application_1.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Cloud_Application_1.dll"]