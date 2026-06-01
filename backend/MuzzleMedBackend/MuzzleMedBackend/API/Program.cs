using System.Reflection.Metadata;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using MuzzleMedBackend.Core.Contexts.Auth.UseCases;
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
using MuzzleMedBackend.Infrastructure.Contexts.Veterinarians.Persistence;
using MuzzleMedBackend.Infrastructure.Contexts.Schedule.Repositories;
using MuzzleMedBackend.Core.Contexts.Schedule.UseCases;

var builder = WebApplication.CreateBuilder(args);

var _secretKey = Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"] ?? "ChaveSecretaDeDesenvolvimentoMuitoLongaEConfigurada123!");

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
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var serverVersion = new MySqlServerVersion(new Version(8, 0, 39));

builder.Services.AddDbContext<AuthDbContext>(options =>
    options.UseMySql(connectionString, serverVersion));

builder.Services.AddDbContext<ScheduleDbContext>(options =>
    options.UseMySql(connectionString, serverVersion));

builder.Services.AddDbContext<VeterinaryDbContext>(options =>
    options.UseMySql(connectionString, serverVersion));

builder.Services.AddTransient<ITokenService, TokenService>();
builder.Services.AddScoped<IUserAuthContextRepository, UserAuthContextRepository>();
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddTransient<LoginUseCase>();
builder.Services.AddTransient<ICreateAppointmentUseCase, CreateAppointmentUseCase>();

builder.Services.AddScoped<IVetRepository, VeterinarianRepository>();
builder.Services.AddScoped<GetVetsAllUseCase>();
builder.Services.AddScoped<GetVetsByClinicIdUseCase>();
builder.Services.AddScoped<PostVetsUseCase>();

builder.Services.AddScoped<IClinicRepository, ClinicRepository>();
builder.Services.AddScoped<GetAllClinicsUseCase>();
builder.Services.AddScoped<CreateClinicUseCase>();

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

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.MapGet("/", () => Results.Redirect("/swagger"));

app.Run();