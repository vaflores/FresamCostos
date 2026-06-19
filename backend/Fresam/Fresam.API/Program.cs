using Fresam.API.Security;
using Fresam.Application.Configurations;
using Fresam.Application.Interfaces;
using Fresam.Application.Interfaces.Repositories;
using Fresam.Application.Interfaces.Repositories.Security;
using Fresam.Application.Interfaces.Security;
using Fresam.Application.Services;
using Fresam.Application.Services.Security;
using Fresam.Infrastructure.Data;
using Fresam.Infrastructure.Repositories;
using Fresam.Infrastructure.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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
builder.Services.AddScoped<IPerfilSeguridadUsuarioService, PerfilSeguridadUsuarioService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IJwtService, JwtService>();

//Repositories
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IModuloRepository, ModuloRepository>();
builder.Services.AddScoped<IRolRepository, RolRepository>();
builder.Services.AddScoped<IPermisoRepository, PermisoRepository>();
builder.Services.AddScoped<IPantallaRepository, PantallaRepository>();
builder.Services.AddScoped<IUsuarioRolRepository, UsuarioRolRepository>();
builder.Services.AddScoped<IPantallaPermisoRepository, PantallaPermisoRepository>();
builder.Services.AddScoped<IRolPantallaPermisoRepository, RolPantallaPermisoRepository>();
builder.Services.AddScoped<IPerfilSeguridadUsuarioRepository, PerfilSeguridadUsuarioRepository>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();

//Configurations
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));

var jwtSettings =
    builder.Configuration
        .GetSection("JwtSettings")
        .Get<JwtSettings>();

if (jwtSettings is null)
{
    throw new InvalidOperationException(
        "No se encontró la configuración JwtSettings.");
}

builder.Services
    .AddAuthentication(
        JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters =
            new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,

                ValidIssuer = jwtSettings!.Issuer,
                ValidAudience = jwtSettings.Audience,

                IssuerSigningKey =
                    new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(
                            jwtSettings.Key))
            };
    });

//Dapper Context
builder.Services.AddScoped<DapperContext>();

//Security
builder.Services.AddSingleton<IAuthorizationHandler,PermissionAuthorizationHandler>();
builder.Services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Fresam API",
        Version = "v1"
    });

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Ingrese el token JWT."
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
