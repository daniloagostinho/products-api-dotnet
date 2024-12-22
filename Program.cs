using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Configura CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

// Adiciona suporte a controladores
builder.Services.AddControllers();

// Configura JSON
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.PropertyNamingPolicy = null; // Desativa camelCase no JSON (opcional)
});

var app = builder.Build();

app.UseCors();
app.UseRouting();

// Rota principal (Hello, World!)
app.MapGet("/", () => "Hello, World!");

// Mapeia os controladores
app.MapControllers();

app.Run();
