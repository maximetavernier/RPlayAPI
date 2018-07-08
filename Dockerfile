# Introduction
FROM microsoft/aspnetcore-build:2.0 AS build-env
LABEL maintainer="maximetavernier92@gmail.com"
LABEL version="0.0.1"

# Create archi
RUN mkdir -p /app
WORKDIR /app

# Build & clean
COPY . ./
WORKDIR /app/src
RUN dotnet restore
RUN dotnet publish rplay-api.sln -c Release -r linux-x64 -o ../../out

# Use private docker image in order to provide a postgresql server instance
FROM maximetavernier92/aspnetcore-postgresql:0.0.2
# Create archi
WORKDIR /app
COPY --from=build-env /app .

# Create base & import dump
RUN /etc/init.d/postgresql start && createdb rplay_db && psql -d rplay_db -f sql/dump.sql && psql -d rplay_db -f sql/setup.sql
RUN rm -rf sql

# Start
EXPOSE 8081
ENTRYPOINT [ "dotnet", "out/api.dll" ]
