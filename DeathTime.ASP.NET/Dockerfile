FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 5024
EXPOSE 5025


FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["DeathTime.ASP.NET/DeathTime.ASP.NET.csproj", "DeathTime.ASP.NET/"]
RUN dotnet restore "./DeathTime.ASP.NET/DeathTime.ASP.NET.csproj"
COPY . .
WORKDIR "/src/DeathTime.ASP.NET"
RUN dotnet tool install --global dotnet-ef 
ENV PATH="$PATH:/root/.dotnet/tools"
RUN dotnet build "./DeathTime.ASP.NET.csproj" -c $BUILD_CONFIGURATION -o /app/build
CMD dotnet ef database update --environment Production --project src/TASK-FLOW.NET

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./DeathTime.ASP.NET.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DeathTime.ASP.NET.dll"]