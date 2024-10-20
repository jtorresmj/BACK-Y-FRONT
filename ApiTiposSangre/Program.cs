using Microsoft.EntityFrameworkCore;
using ApiTiposSangre.Models;

var builder = WebApplication.CreateBuilder(args);

string? cadena = builder.Configuration.GetConnectionString("DefaultConnection") ?? "OtraCadena";
builder.Services.AddControllers();
builder.Services.AddDbContext<Conexiones>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
    //opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); conexion para sqlServer
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
