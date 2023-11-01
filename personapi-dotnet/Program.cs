using personapi_dotnet.Interfaces;
using personapi_dotnet.Repositories;
using personapi_dotnet.Models.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Obtener la cadena de conexión
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Registrar PersonaDbContext
builder.Services.AddDbContext<PersonaDbContext>(options =>
    options.UseSqlServer(connectionString));

// Registra tus repositorios y otros servicios aquí
builder.Services.AddScoped<IPersonaRepository, PersonaRepository>();
builder.Services.AddScoped<IEstudiosRepository, EstudiosRepository>();
builder.Services.AddScoped<IProfesionRepository, ProfesionRepository>();
builder.Services.AddScoped<ITelefonoRepository, TelefonoRepository>();

// Agregar servicios al contenedor.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configurar el middleware para el enrutamiento
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers(); // Utilizar MapControllers para las API

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
