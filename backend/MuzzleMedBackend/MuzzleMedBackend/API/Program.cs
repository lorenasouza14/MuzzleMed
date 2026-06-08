using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using System.Text.Json.Serialization;
using MuzzleMedBackend.Core.Contexts.Auth.UseCases;
using MuzzleMedBackend.Core.Contexts.Schedule.UseCases;
using MuzzleMedBackend.Core.Contexts.Veterinarians.UseCases;
using MuzzleMedBackend.Domain.Contexts.Auth.Interfaces.Repositories;
using MuzzleMedBackend.Domain.Contexts.Auth.Interfaces.Services;
using MuzzleMedBackend.Domain.Contexts.Schedule.Interfaces;
using MuzzleMedBackend.Domain.Contexts.Schedule.Interfaces.IUseCases;
using MuzzleMedBackend.Domain.Contexts.Veterinarians.Interfaces;
using MuzzleMedBackend.Infrastructure;
using MuzzleMedBackend.Infrastructure.Contexts.Auth.Repositories;
using MuzzleMedBackend.Infrastructure.Contexts.Schedule.Persistence;
using MuzzleMedBackend.Infrastructure.Contexts.Schedule.Repositories;
using MuzzleMedBackend.Infrastructure.Contexts.Veterinarians.Repositories;
using MuzzleMedBackend.Infrastructure.Security;
using MuzzleMedBackend.Core.Contexts.Profile.UseCases;
using MuzzleMedBackend.Core.Contexts.Schedule.UseCases.AppointmentScheduleUseCases;
using MuzzleMedBackend.Core.Contexts.Schedule.UseCases.HistoricAppointmentsUseCases;
using MuzzleMedBackend.Core.Contexts.Schedule.UseCases.PetScheduleUseCases;
using MuzzleMedBackend.Domain.Contexts.Auth.Interfaces.UseCases;
using MuzzleMedBackend.Domain.Contexts.Profile.Interfaces;
using MuzzleMedBackend.Domain.Contexts.Profile.Interfaces.UseCases;
using MuzzleMedBackend.Domain.Contexts.Schedule.Interfaces.Repositories;
using MuzzleMedBackend.Domain.Contexts.Schedule.Interfaces.UseCases;
using MuzzleMedBackend.Infrastructure.Contexts.Profile.Repositories;
using MuzzleMedBackend.Services;
using MuzzleMedBackend.Services.Interfaces;

//Configs
var builder = WebApplication.CreateBuilder(args);

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
builder.Services.AddOpenApi();
builder.Services.AddControllers() 
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); //Converter os enums
    });

//Configs do Banco de dados
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var serverVersion = new MySqlServerVersion(new Version(8, 0, 39));

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, serverVersion));

//Injeção de dependencia

// Auth
builder.Services.AddTransient<ITokenService, TokenService>();
builder.Services.AddScoped<IUserAuthContextRepository, UserAuthContextRepository>();
builder.Services.AddTransient<LoginUseCase>();

// Schedule
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddTransient<ICreateAppointmentUseCase, CreateAppointmentUseCase>();
builder.Services.AddScoped<IGetAppointmentsByUserUseCase, GetAppointmentsByUserUseCase>();
builder.Services.AddScoped<IGetAppointmentByIdUseCase, GetAppointmentByIdUseCase>();
builder.Services.AddScoped<ICancelAppointmentScheduleUseCase, CancelAppointmentScheduleUseCase>();
builder.Services.AddScoped<IUpdateAppointmentScheduleUseCase, UpdateAppointmentScheduleUseCase>();

// Veterinarians
builder.Services.AddScoped<IVetRepository, VeterinarianRepository>();
builder.Services.AddScoped<GetVetsAllUseCase>();
builder.Services.AddScoped<GetVetsByClinicIdUseCase>();
builder.Services.AddScoped<PostVetsUseCase>();

// Clinics
builder.Services.AddScoped<IClinicRepository, ClinicRepository>();
builder.Services.AddScoped<GetAllClinicsUseCase>();
builder.Services.AddScoped<CreateClinicUseCase>();

// Profile, Schedule Projections Auth Integration
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<CreateUserUseCase>();

builder.Services.AddScoped<IPetRepository, PetRepository>();
builder.Services.AddScoped<CreatePetUseCase>();

builder.Services.AddScoped<ICreateAuthUserUseCase, CreateAuthUserUseCase>();

builder.Services.AddScoped<IUserScheduleRepository, UserScheduleRepository>();
builder.Services.AddScoped<ICreateUserScheduleUseCase, CreateUserScheduleUseCase>();
builder.Services.AddScoped<IUpdateUserScheduleUseCase, UpdateUserScheduleUseCase>();
builder.Services.AddScoped<GetUserProfileUseCase>();
builder.Services.AddScoped<UpdateUserUseCase>();

builder.Services.AddScoped<IPetScheduleRepository, PetScheduleRepository>();
builder.Services.AddScoped<ICreatePetScheduleUseCase, CreatePetScheduleUseCase>();
builder.Services.AddScoped<GetPetsByUserUseCase>();
builder.Services.AddScoped<IHistoricAppointmentRepository, HistoricAppointmentRepository>();
builder.Services.AddScoped<GetPetHistoryUseCase>();

builder.Services.AddScoped<IFinalizeAppointmentUseCase, FinalizeAppointmentUseCase>();
builder.Services.AddScoped<ICreateHistoricUseCase, CreateHistoricUseCase>();
builder.Services.AddScoped<IGetHistoricByIdUseCase, GetHistoricByIdUseCase>();
builder.Services.AddScoped<IGetHistoricByPetUseCase, GetHistoricByPetUseCase>();
builder.Services.AddScoped<IHistoricAppointmentRepository, HistoricAppointmentRepository>();

//Services
//service para nos pegarmos o id do usuario pelo jwt
builder.Services.AddScoped<IGetUserIdService, GetUserIdService>();
builder.Services.AddHttpContextAccessor();


// MIDDLEWARES E PIPELINE DA APLICAÇÃO
var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.MapGet("/", () => Results.Redirect("/swagger"));

app.Run();