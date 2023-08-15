FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src
COPY . .
RUN dotnet restore "LoggingBestPractices.Benchmarks/LoggingBestPractices.Benchmarks.csproj"

WORKDIR "/src/LoggingBestPractices.Benchmarks"
RUN dotnet build "LoggingBestPractices.Benchmarks.csproj" -c Release
RUN dotnet publish "LoggingBestPractices.Benchmarks.csproj" -c Release /p:UseAppHost=false
