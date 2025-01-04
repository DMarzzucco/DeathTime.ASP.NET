using DeathTime.ASP.NET.Configurations;
using DeathTime.ASP.NET.Configurations.Swagger;
using DeathTime.ASP.NET.Configurations.DatabaseConfig;
using DeathTime.ASP.NET.Utils.MIddleware;
using DeathTime.ASP.NET.Context;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

//DatabaseConfig
builder.Services.AddDatabaseConfiguration(builder.Configuration);

// Register Filters
builder.Services.AddControllersCustom();

// Register Services
builder.Services.AddServicesCustom();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfigurations();

//Cors Policy
builder.Services.AddCorsPolicy();

//mapper
builder.Services.AddMapperConfigurations();

builder.Services.AddMvc();

// port listen
builder.WebHost.UseUrls("http://*:5024");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<DeathTimerMid>();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseCors("DeathTimerCors");

app.UseAuthorization();

using (var scope = app.Services.CreateScope()) {
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate();
}

app.MapControllers();

app.Run();
