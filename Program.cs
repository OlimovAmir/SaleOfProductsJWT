using Microsoft.EntityFrameworkCore;
using Npgsql;
using SaleOfProductsJWT.Infrastructure;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
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
builder.Services.AddSwaggerGen();

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

app.UseCors("AllowLocalhost"); // Применяем CORS middleware

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
