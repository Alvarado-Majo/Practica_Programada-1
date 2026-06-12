using Microsoft.EntityFrameworkCore;
using PracticaProgramada1.BLL;
using PracticaProgramada1.BLL.Services;
using PracticaProgramada1.DAL.Data;
using PracticaProgramada1.DAL.Repositorios;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();


builder.Services.AddDbContext<PracticaDBContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IClienteServicio, ClienteServicio>();
builder.Services.AddScoped<IClienteRepositorio, ClienteRepositorio>();


builder.Services.AddAutoMapper(cfg => { }, typeof(MapeoClases)); 



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
