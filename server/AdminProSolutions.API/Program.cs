using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json.Serialization;
using AdminProSolutions.Domain.Model;
using AdminProSolutions.Infrastructure.Data;
using AdminProSolutions.Domain.Interfaces.Base;
using AdminProSolutions.Domain.Interfaces.Messenger;
using AdminProSolutions.Domain.Interfaces.Authentication;
using AdminProSolutions.Domain.Interfaces.Miscellaneous;
using AdminProSolutions.Infrastructure.Repositories.Authentication;
using AdminProSolutions.Infrastructure.Repositories.Base;
using AdminProSolutions.Infrastructure.Repositories.Messenger;
using AdminProSolutions.Infrastructure.Repositories.Miscellaneous;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using AdminProSolutions.Domain.Interfaces.Organization;
using AdminProSolutions.Infrastructure.Repositories.Organization;

var builder = WebApplication.CreateBuilder(args);

/* Add services to the container. */
builder.Services.AddControllers().AddJsonOptions(options =>
{
    /* Ignore self reference loop */
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    /* set as pascal case */
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});

/* configure strongly typed settings objects */
var appSettingsSection = builder.Configuration.GetSection("AppSettings");
builder.Services.Configure<AppSettings>(appSettingsSection);
var appSettings = appSettingsSection.Get<AppSettings>();

/* Db Context and Database connection. */
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(appSettings.DefaultConnection);
});

/* Mapped one object to other. */
builder.Services.AddAutoMapper(typeof(Program));

/* ===== Add jwt authentication ======== */
var key = Encoding.ASCII.GetBytes(appSettings.SecretKey);
builder.Services.AddAuthentication(x =>
{    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

/* New instance is provided to every controller and every service. */
builder.Services.AddTransient<IActiveDirectory, ActiveDirectoryRepository>();
builder.Services.AddTransient<IAuthetication, AuthenticationRepository>();
builder.Services.AddTransient<IAudit, AuditRepository>();
builder.Services.AddTransient<IUsers, UserRepository>();
builder.Services.AddTransient<IGroups, RoleRepository>();
builder.Services.AddTransient<IEmail, EmailRepository>();
builder.Services.AddTransient<IClients, ClientRepository>();
builder.Services.AddTransient<IEmployees, EmployeeRepository>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

/* Global cors policy */
app.UseCors(builder =>
{
    builder.AllowAnyHeader();
    builder.AllowAnyMethod();
    builder.AllowAnyOrigin();
});


/* Configure the HTTP request pipeline. */
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Configure static files
app.UseStaticFiles();

// Enable default files (like index.html) to be served from wwwroot
app.UseDefaultFiles();

app.MapControllers();

/* Sedding Database. */
var serviceScope = ((IApplicationBuilder)app).ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();

if (!serviceScope.ServiceProvider.GetService<DataContext>().AllMigrationsApplied())
{
    serviceScope.ServiceProvider.GetService<DataContext>().Database.Migrate();
    serviceScope.ServiceProvider.GetService<DataContext>().EnsureSeeded();
}
else
{
    serviceScope.ServiceProvider.GetService<DataContext>().EnsureSeeded();
}

// Fallback route for SPA
app.MapFallbackToFile("index.html");

app.Run();
