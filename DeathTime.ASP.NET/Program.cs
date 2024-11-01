using DeathTime.ASP.NET.Context;
using DeathTime.ASP.NET.Filters;
using DeathTime.ASP.NET.User.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//build StringConection
var connectionString = builder.Configuration.GetConnectionString("Connection");

// Register Server
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));

// Register Filters
builder.Services.AddControllers(options =>
{
    options.Filters.Add<GlobalFilterExceptions>();
});

// Register Services
builder.Services.AddScoped<UserServices>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
