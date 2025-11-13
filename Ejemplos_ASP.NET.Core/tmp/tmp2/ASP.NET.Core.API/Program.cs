var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerUI();            // SwaggerUI.OpenApi - paquete de terceros

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapSwaggerUI();                       // habilita UI, ruta por defecto /swagger o / (depende del paquete)
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
