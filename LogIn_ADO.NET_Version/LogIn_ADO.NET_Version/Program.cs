using LogIn_ADO.NET_Version.Data;
using LogIn_ADO.NET_Version.Data.Interfaz;
using LogIn_ADO.NET_Version.Data.Service;
using Microsoft.AspNetCore.Authentication.Cookies;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<Conect>();
// Register the Conect service to be used for database connections
builder.Services.AddScoped<InterUsser, ServiceUsser>();
// Register the InterUsser interface with its implementation ServiceUsser
builder.Services.AddScoped<Intercompetencia, Servicecompetencia>();
// Register the Intercompetencia interface with its implementation Servicecompetencia
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie( option =>
    {
        option.LoginPath = "/Home/Index"; //Si funciona, pasará la página de log in
        option.ExpireTimeSpan = TimeSpan.FromMinutes(20); //Desconecta luego de 20 minutos
        option.AccessDeniedPath = "/Home/Privacy"; //Si no funciona, manda a la página de privacidad
    }
    );
//Este sistema permite guardar el acceso mediante las cookies del navegador

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
