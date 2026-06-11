using Fresam.Application.Interfaces;
using Fresam.Application.Services;
using Fresam.Application.Interfaces.Repositories;
using Fresam.Infrastructure.Repositories;
using Fresam.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Services
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IModuloService, ModuloService>();
builder.Services.AddScoped<IRolService, RolService>();
builder.Services.AddScoped<IPermisoService, PermisoService>();
builder.Services.AddScoped<IPantallaService, PantallaService>();
builder.Services.AddScoped<IUsuarioRolService, UsuarioRolService>();
builder.Services.AddScoped<IPantallaPermisoService, PantallaPermisoService>();
builder.Services.AddScoped<IRolPantallaPermisoService, RolPantallaPermisoService>();

//Repositories
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IModuloRepository, ModuloRepository>();
builder.Services.AddScoped<IRolRepository, RolRepository>();
builder.Services.AddScoped<IPermisoRepository, PermisoRepository>();
builder.Services.AddScoped<IPantallaRepository, PantallaRepository>();
builder.Services.AddScoped<IUsuarioRolRepository, UsuarioRolRepository>();
builder.Services.AddScoped<IPantallaPermisoRepository, PantallaPermisoRepository>();
builder.Services.AddScoped<IRolPantallaPermisoRepository, RolPantallaPermisoRepository>();

//Dapper Context
builder.Services.AddScoped<DapperContext>();

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
