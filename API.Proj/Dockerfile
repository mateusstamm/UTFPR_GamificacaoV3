FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

#ENV ASPNETCORE_URLS http://*:5239
#ENV ASPNETCORE_ENVIRONMENT=Development

COPY . ./
RUN dotnet restore

RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./

EXPOSE 5239

ENTRYPOINT ["dotnet", "API.dll"]
