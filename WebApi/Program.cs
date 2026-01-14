using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using Aplication.UseCase;
using Domain.Interfaces;
using Infraestructure.Repositorios;
using Aplication.Mapping;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// =========================
// Servicios
// =========================

builder.Services.AddControllers();

// 🔹 DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

// 🔹 AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

// 🔹 Repositorios
builder.Services.AddScoped<IEstudiante, EstudianteRepositorio>();
builder.Services.AddScoped<IContactoCallCenter, ContactoCallCenterRepository>();

// 🔹 Casos de uso
builder.Services.AddScoped<EstudianteUseCase>();
builder.Services.AddScoped<ContactoCallCenterUseCase>();
builder.Services.AddScoped<MarketingUseCase>();
builder.Services.AddScoped<DashboardUseCase>();

// 🔹 CORS (FRONTEND)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy
                .WithOrigins("http://localhost:5173") // Vite
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

// 🔹 Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// =========================
// Middleware
// =========================

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// 🔹 HABILITAR CORS
app.UseCors("AllowFrontend");

app.UseAuthorization();

app.MapControllers();

app.Run();
