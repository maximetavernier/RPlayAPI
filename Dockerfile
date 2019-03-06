# Introduction
FROM microsoft/dotnet:2.1-sdk AS build-env
LABEL maintainer="maximetavernier92@gmail.com"
LABEL version="0.0.1"

# Create archi
RUN mkdir -p /app
WORKDIR /app

# Build & clean
COPY . ./
WORKDIR /app/src
RUN dotnet publish rplay-api.sln -c Release -r linux-x64 -o ../../out

# Tests
#RUN dotnet test src/rplay-tests/rplay-tests.csproj

# Use private docker image in order to provide a postgresql server instance
FROM microsoft/aspnetcore:2.0
# Create archi
RUN mkdir -p /app
WORKDIR /app
COPY --from=build-env /app/out .

# Start
EXPOSE 8081
ENTRYPOINT [ "dotnet", "api.dll" ]
