FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY *.sln ./
COPY CoreWebAPI/CoreWebAPI.csproj CoreWebAPI/
RUN dotnet restore

COPY . .

ENV TEAMCITY_PROJECT_NAME=fake
RUN dotnet test CoreWebAPI.Tests/CoreWebAPI.Tests.csproj

WORKDIR /src/CoreWebAPI
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CoreWebAPI.dll"]