using System.Reflection.Metadata;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using MuzzleMedBackend.Core.Contexts.Auth.UseCases;
// ADICIONADOS: Usings do contexto de Veterinários
using MuzzleMedBackend.Core.Contexts.Veterinarians.UseCases;
using MuzzleMedBackend.Core.Contexts.Schedule.UseCases.AppointmentUseCases;
using MuzzleMedBackend.Domain.Contexts.Auth.Entities;
using MuzzleMedBackend.Domain.Contexts.Auth.Interfaces.Repositories;
using MuzzleMedBackend.Domain.Contexts.Auth.Interfaces.Services;
using MuzzleMedBackend.Domain.Contexts.Veterinarians.Interfaces;
using MuzzleMedBackend.Infrastructure.Contexts.Auth.Repositories;
using MuzzleMedBackend.Infrastructure.Contexts.Veterinarians.Repositories;
using MuzzleMedBackend.Infrastructure.Persistence;
using MuzzleMedBackend.Infrastructure.Security;
using MuzzleMedBackend.Domain.Contexts.Auth.ValueObjects;
using MuzzleMedBackend.Domain.Contexts.Schedule.Interfaces;
using MuzzleMedBackend.Domain.Contexts.Schedule.Interfaces.IUseCases;
using MuzzleMedBackend.Infrastructure.Contexts.Schedule.Persistence;

var builder = WebApplication.CreateBuilder(args);

//Configuracao para autorizar o token JWT
var _secretKey = Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]);
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(x =>
    {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(_secretKey),
            ValidateIssuer = false,
            ValidateAudience = false,
        };
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => {
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        Description = "JWT Authorization header using the Bearer scheme."
    });
    options.AddSecurityRequirement(document => new OpenApiSecurityRequirement
    {
        [new OpenApiSecuritySchemeReference("Bearer", document)] = []
    });
});

builder.Services.AddAuthorization();

// Add services to the container.
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// FIXADO: Definindo a versão do MySQL manualmente (8.0.39) para evitar erros de conexão em Design Time
var serverVersion = new MySqlServerVersion(new Version(8, 0, 39));

// Configuração do Banco AuthDbContext
builder.Services.AddDbContext<AuthDbContext>(options =>
    options.UseMySql(connectionString, serverVersion));

// Configuração do Banco ScheduleDbContext
builder.Services.AddDbContext<ScheduleDbContext>(options =>
    options.UseMySql(connectionString, serverVersion));

// Configuração do Banco MuzzleMedDbContext
builder.Services.AddDbContext<MuzzleMedDbContext>(options =>
    options.UseMySql(connectionString, serverVersion));

// =========================================================================
// REGISTROS DO CONTEXTO DE AUTENTICAÇÃO (Já existentes)
// =========================================================================
builder.Services.AddTransient<ITokenService, TokenService>();
builder.Services.AddScoped<IUserAuthContextRepository, UserAuthContextRepository>();
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddTransient<LoginUseCase>();
builder.Services.AddTransient<ICreateAppointmentUseCase, CreateAppointmentUseCase>();

// =========================================================================
// NOVO: REGISTROS DO CONTEXTO DE VETERINÁRIOS
// =========================================================================
// 1. Registro do Repositório de Veterinários
builder.Services.AddScoped<IVetRepository, VeterinarianRepository>();

// 2. Registro dos Use Cases de Veterinários
builder.Services.AddScoped<GetVetsAllUseCase>();
builder.Services.AddScoped<GetVetsByClinicIdUseCase>();
builder.Services.AddScoped<PostVetsUseCase>(); // Esse cara ativa a sua rota POST!
// =========================================================================

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AuthDbContext>();

    if (!dbContext.UsersAuth.Any())
    {
        var usuarioTeste = new UserAuthContext(
            new Email("lucas@vet.com"),
            "senha123"
        );

        dbContext.UsersAuth.Add(usuarioTeste);
        dbContext.SaveChanges();

        Console.WriteLine("Usuário de teste 'lucas@vet.com' criado com sucesso!");
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(); // Isso garante que a interface visual do Swagger abra em /swagger
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.MapGet("/", () => Results.Redirect("/swagger"));

app.Run();