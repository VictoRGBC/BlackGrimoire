using DnDSpells.Application.Interfaces;
using DnDSpells.Infrastructure.Context;
using DnDSpells.Infrastructure.Repositories;


// Usar sua classe concreta do repositório aqui
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuração do SQLite e EF Core
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IMagiaRepository, MagiaRepository>();

// Injeção de Dependência
// builder.Services.AddScoped<IMagiaRepository, MagiaRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); // Swagger já vem por padrão nos templates modernos

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();