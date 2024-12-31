using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using StackExchange.Redis;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
// Swagger/OpenAPI configuration
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Controllers
builder.Services.AddControllers();

// CORS configuration
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

// Add DbContext (SQL Server)
builder.Services.AddDbContext<DbConfig>(options =>
{
    options.UseSqlServer(
              "Server=localhost;Database=EmploymentSystem2;User Id=sa;Password=YourPassword123;Trusted_Connection=False;Encrypt=True;TrustServerCertificate=true"
    );
});

// Add Redis (commented out, can be enabled if required)
#region Redis Configuration
// string redisConnectionString = builder.Configuration.GetConnectionString("Redis") ?? "localhost:6379";
// builder.Services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect(redisConnectionString));
#endregion

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        // Get the secret key from the configuration
        var jwtKey = builder.Configuration["Jwt:Key"];
        
        if (string.IsNullOrEmpty(jwtKey))
        {
            throw new ArgumentNullException("Jwt:Key", "JWT key is missing in the configuration.");
        }

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false, // No issuer validation
            ValidateAudience = false, // No audience validation
            ValidateLifetime = true, // Token expiration check
            ValidateIssuerSigningKey = true, // Validate the signing key
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey)) // Secret key for signing
        };
    });

// Register repositories and DbContext
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IVacancyRepository, VacancyRepository>();
builder.Services.AddScoped<IApplicationRepository, ApplicationRepository>();
builder.Services.AddScoped<DbConfig>();

// Add MediatR for CQRS and Mediator pattern
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapControllers();
    app.UseCors();
    app.UseDeveloperExceptionPage();
    app.UseRouting();
}

// Common middlewares
app.UseHttpsRedirection();

// Root endpoint
app.MapGet("/", () =>
{
    return "Hello";
})
.WithName("Employment System")
.WithOpenApi();

// Enable Authentication and Authorization middleware
app.UseAuthentication();
app.UseAuthorization();

app.Run();
