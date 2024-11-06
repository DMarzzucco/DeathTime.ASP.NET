FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /App

# Copy and Restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything
COPY . ./

# Build and publish a release
RUN dotnet publish -c Release -o out


# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /App


# Copy all files 
COPY --from=build-env /App/out .

# PORT
EXPOSE 5024

ENTRYPOINT ["dotnet", "DeathTime.ASP.NET.dll"]