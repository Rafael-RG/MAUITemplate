
FROM mcr.microsoft.com/azure-functions/dotnet-isolated:4-dotnet-isolated8.0 AS base
WORKDIR /home/site/wwwroot
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Backend.Services/Backend.Services.csproj", "Backend.Services/"]
COPY ["Backend.Common/Backend.Common.csproj", "Backend.Common/"]
COPY ["Backend.Models/Backend.Models.csproj", "Backend.Models/"]
COPY ["Backend.DataAccess/Backend.DataAccess.csproj", "Backend.DataAccess/"]
RUN dotnet restore "./Backend.Services/./Backend.Services.csproj"
COPY . .

WORKDIR "/src/Backend.Services"
RUN dotnet build "./Backend.Services.csproj" -c "${BUILD_CONFIGURATION}" -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Backend.Services.csproj" -c "${BUILD_CONFIGURATION}" -o /app/publish /p:UseAppHost=false



FROM base AS final
WORKDIR /home/site/wwwroot

# Create a group and user
RUN groupadd -g 1001 appgroup && \
    useradd -u 1001 -g appgroup -m appuser

# Tell docker that all future commands should run as the appuser user
USER appuser

COPY --from=publish /app/publish .
ENV AzureWebJobsScriptRoot=/home/site/wwwroot \
    AzureFunctionsJobHost__Logging__Console__IsEnabled=true