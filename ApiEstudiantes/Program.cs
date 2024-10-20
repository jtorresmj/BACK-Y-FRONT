using Microsoft.EntityFrameworkCore;
using ApiEstudiantes.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string? cadena = builder.Configuration.GetConnectionString("DefaultConnection") ?? "OtraCadena";
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddDbContext<Conexiones>(opt =>
     opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
    //opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); conexion para sqlServer
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient();

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