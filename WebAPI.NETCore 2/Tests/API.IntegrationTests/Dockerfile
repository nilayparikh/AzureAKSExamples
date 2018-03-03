FROM microsoft/dotnet:2.0-sdk AS build
WORKDIR /src

COPY ./API.IntegrationTests.csproj ./
RUN dotnet restore

COPY . .

ENV TEAMCITY_PROJECT_NAME=fake
RUN dotnet test ./API.IntegrationTests.csproj