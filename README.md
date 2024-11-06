# Death Time Middleware in APIsREST with .NET

This is an example of how the Death Time middleware works in ASP.NET.

## Before Installation

Before testing the application, it is recommended to check the source code to configure the counter. The soruce code is located at: `./DeathTime.ASP.NET/Middleware/DeathTimerMid.cs`. 

```TS 
var deathTimer = DateTime.ParseExact("0000-00-00T00:00:00", "yyyy-MM-ddTHH:mm:ss", ...);
```

# Requirements

* Docker [Docker-Desktop](https://www.docker.com/products/docker-desktop/)
* .NET 8.0  [.NET](https://dotnet.microsoft.com/es-es/download)

## Installation

```bash

#Start Data Base
docker-compose up db

#Create a Migrations
Add-Migration Initial

#Update the database
Update-Database

#RunApp
dotnet Run

```

## Port

[localhost:5024](http://localhost:5024)

## Documentation

The server code is documented in Swagger. You can acces it at [localhost:3001/docs](http://localhost:5024/Swagger/)


## Author

Made by Dario Marzzucco (DMarzzucco)
