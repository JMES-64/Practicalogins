using LogIn_ADO.NET_Version.Data;
using LogIn_ADO.NET_Version.Data.Interfaz;
using LogIn_ADO.NET_Version.Data.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<Conect>();
// Register the Conect service to be used for database connections
builder.Services.AddScoped<InterUsser, ServiceUsser>();
// Register the InterUsser interface with its implementation ServiceUsser
builder.Services.AddScoped<Intercompetencia, Servicecompetencia>();
// Register the Intercompetencia interface with its implementation Servicecompetencia
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

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
