using AutoMapper;
using DeathTime.ASP.NET.Context;
using DeathTime.ASP.NET.Filters;
using DeathTime.ASP.NET.Mapper;
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

//Cors Policy
builder.Services.AddCors(o =>
{
    o.AddPolicy("DeathTimerCors", b =>
    {
        b.WithOrigins("http://localhost:3000")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials();
    });
});

//mapper
var mappConfig = new MapperConfiguration(m =>
{
    m.AddProfile<MappingProfile>();
});
IMapper mapper = mappConfig.CreateMapper();

builder.Services.AddSingleton(mapper);
builder.Services.AddMvc();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("DeathTimerCors");

app.UseAuthorization();

app.MapControllers();

app.Run();
