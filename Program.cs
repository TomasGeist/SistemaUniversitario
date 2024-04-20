using Microsoft.EntityFrameworkCore;
using WSSistemaUniversitario.DTOs;
using WSSistemaUniversitario.Models;
using WSSistemaUniversitario.Models.Response;
using WSSistemaUniversitario.Services;
using WSSistemaUniversitario.Tools;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DbSistemauniversitarioContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbUniversitario"));
});
builder.Services.AddScoped<AlumnoService>();
builder.Services.AddScoped<Respuesta>();

//DTOS
builder.Services.AddScoped<CambioDeCondicionAlumnoDTO>();

//TOOLS
builder.Services.AddSingleton<Verificaciones>();


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
