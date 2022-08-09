FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["LoggingStudyCase/LoggingStudyCase.csproj", "LoggingStudyCase/"]
RUN dotnet restore "LoggingStudyCase/LoggingStudyCase.csproj"
COPY . .
WORKDIR "/src/LoggingStudyCase"
RUN dotnet build "LoggingStudyCase.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LoggingStudyCase.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LoggingStudyCase.dll"]
