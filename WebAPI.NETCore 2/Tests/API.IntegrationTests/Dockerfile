#FROM microsoft/dotnet:2.0-runtime AS base
#WORKDIR /app

FROM microsoft/dotnet:2.0-sdk AS build
WORKDIR /src
COPY *.sln ./
COPY Tests/API.IntegrationTests/API.IntegrationTests.csproj Tests/API.IntegrationTests/
RUN dotnet restore
COPY . .
WORKDIR /src/Tests/API.IntegrationTests
RUN dotnet build

#FROM build AS publish
#RUN dotnet publish -c Release -o /app

#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app .
ENTRYPOINT ["dotnet", "test"]
