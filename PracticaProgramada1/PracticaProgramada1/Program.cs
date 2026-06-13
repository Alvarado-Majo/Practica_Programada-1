using Microsoft.EntityFrameworkCore;
using PracticaProgramada1.BLL;
using PracticaProgramada1.BLL.Services.Cliente;
using PracticaProgramada1.DAL.Data;
using PracticaProgramada1.DAL.Repositorios.Cliente;
using PracticaProgramada1.DAL.Repositorios.Telefono;

var builder = WebApplication.CreateBuilder(args);

// Registro de servicios antes del build
builder.Services.AddControllersWithViews();

// DbContext
builder.Services.AddDbContext<PracticaDBContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Inyección de dependencias
builder.Services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
builder.Services.AddScoped<ITelefonoRepositorio, TelefonoRepositorio>();


//Servicios
builder.Services.AddScoped<IClienteServicio, ClienteServicio>();

//Faltan los servicios de Telefono


//Servicio Terceros
builder.Services.AddAutoMapper(cfg => { }, typeof(MapeoClases));

// app builder
var app = builder.Build();


// Pipeline HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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