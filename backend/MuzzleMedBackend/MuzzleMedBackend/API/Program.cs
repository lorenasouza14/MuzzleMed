using Microsoft.EntityFrameworkCore;
using MuzzleMedBackend.Core.Contexts.Auth.UseCases;
using MuzzleMedBackend.Domain.Contexts.Auth.Interfaces.Repositories;
using MuzzleMedBackend.Infrastructure.Contexts.Auth.Repositories;
using MuzzleMedBackend.Infrastructure.Persistence;
using MuzzleMedBackend.Infrastructure.Security;
using MuzzleMedBackend.Domain.Contexts.Auth.Interfaces.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
// Required for Swagger/OpenAPI to discover controller endpoints
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AuthDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
);
// Register token service as its interface so consumers that depend on ITokenService can be resolved
builder.Services.AddTransient<ITokenService, TokenService>();
builder.Services.AddScoped<IUserAuthContextRepository, UserAuthContextRepository>();
builder.Services.AddTransient<LoginUseCase>();

var app = builder.Build();

// Configure the HTTP request pipeline.
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

app.Run();