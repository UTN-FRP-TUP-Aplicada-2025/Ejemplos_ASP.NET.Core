using Personas.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddOpenApi();
builder.Services.AddSwaggerUI();            // SwaggerUI.OpenApi - paquete de terceros

//builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSingleton<PersonasRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapSwaggerUI();                       // habilita UI, ruta por defecto /swagger o / (depende del paquete)
}
//SwaggerUI.OpenApi
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
