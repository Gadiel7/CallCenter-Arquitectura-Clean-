using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using Aplication.UseCase;
using Domain.Interfaces;
using Infraestructure.Repositorios;
using Aplication.Mapping;
using AutoMapper;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

builder.Services.AddAutoMapper(typeof(MappingProfile));


builder.Services.AddScoped<IEstudiante, EstudianteRepositorio>();
builder.Services.AddScoped<EstudianteUseCase>();
builder.Services.AddScoped<IContactoCallCenter, ContactoCallCenterRepository>();
builder.Services.AddScoped<ContactoCallCenterUseCase>();
builder.Services.AddScoped<MarketingUseCase>();

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
