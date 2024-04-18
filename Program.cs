using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Npgsql;
using SaleOfProductsJWT.Auth;
using SaleOfProductsJWT.Infrastructure;
using SaleOfProductsJWT.Middlewares;
using SaleOfProductsJWT.Repositories;
using SaleOfProductsJWT.Services;
using SaleOfProductsJWT.Services.IService;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMyAuth();

NpgsqlConnection.GlobalTypeMapper.EnableDynamicJson();


builder.Services.AddDbContext<PostgreSQLDbContext>(options =>
           options.UseNpgsql(builder.Configuration.GetConnectionString("DbPostgres"))
           .LogTo(Console.Write, LogLevel.Information)
          .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

builder.Services.AddLogging(l =>
{
    //l.ClearProviders();
    //l.AddConsole();
});

// Add services to the container.

builder.Services.AddControllers()
            .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost",
        builder =>
        {
            builder.WithOrigins("http://localhost:3000") // Разрешение запроса от фронтенд домен
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});




// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "SaleOfProduct application APIs", Version = "v1" });

    // Add the JWT Bearer authentication scheme
    var securityScheme = new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Description = "JWT Authorization header using the Bearer scheme.",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
    };
    c.AddSecurityDefinition("Bearer", securityScheme);

    // Use the JWT Bearer authentication scheme globally
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                { securityScheme, new List<string>() }
            });
});

//Adding custom services



builder.Services.AddSwaggerGen();
builder.Services.AddMyServices();


builder.Services.AddScoped(typeof(IPostgreSQLRepository<>), typeof(PostgreSQLRepository<>));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetService<PostgreSQLDbContext>();
    context.Database.Migrate();    
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<GlobalExceptionMiddleware>();
app.UseMiddleware<ApplicationKeyMiddleware>();
app.UseMiddleware<EndpointListenerMiddleware>();

app.UseCors("AllowLocalhost"); // Применяем CORS middleware

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapGet("MyMinAPI", (string name) => $"Hello {name}");

app.Run();
