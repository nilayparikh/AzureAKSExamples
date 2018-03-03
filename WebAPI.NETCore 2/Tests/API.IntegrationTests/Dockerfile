FROM microsoft/dotnet:2.0-sdk AS base
WORKDIR /app

COPY Tests/API.IntegrationTests/API.IntegrationTests.csproj Tests/API.IntegrationTests/
RUN dotnet restore

COPY . .

ENTRYPOINT ["dotnet", "test"]
