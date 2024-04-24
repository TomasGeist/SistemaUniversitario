using Microsoft.EntityFrameworkCore;
using QuestPDF.Infrastructure;
using WSSistemaUniversitario.Controllers;
using WSSistemaUniversitario.DTOs;
using WSSistemaUniversitario.Models;
using WSSistemaUniversitario.Models.Response;
using WSSistemaUniversitario.Services;
using WSSistemaUniversitario.Tools;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

QuestPDF.Settings.License = LicenseType.Community;

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
builder.Services.AddScoped<RespuestasUtiles>();
builder.Services.AddScoped<PdfPagoService>();
builder.Services.AddScoped<EmailService>();
builder.Services.AddScoped<EnviarEmailController>();
//DTOS
builder.Services.AddScoped<CambioDeCondicionAlumnoDTO>();

//TOOLS
builder.Services.AddScoped<Verificaciones>();
builder.Services.AddScoped<BuscarAlumno>();

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
