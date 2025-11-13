using Personas.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

//agregar esto
#region configuración de restapi y swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#endregion

#region
builder.Services.AddSingleton<PersonasRepository>();
#endregion

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(name: "default",pattern: "{controller=Home}/{action=Index}/{id?}").WithStaticAssets();


//agregar esto
#region configuración swagger
//if (app.Environment.IsDevelopment()) //comentar para que corra en modo release
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapControllers();
#endregion


app.Run();
