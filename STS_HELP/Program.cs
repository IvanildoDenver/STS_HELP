using Microsoft.EntityFrameworkCore;
using STS_HELP;
using STS_HELP.Data;
using STS_HELP.Repositorio;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();



//INJEÇÃO DE DEPENDÊNCIA:
builder.Services.AddEntityFrameworkNpgsql().AddDbContext<BancoContext>( o => o.UseNpgsql(builder.Configuration.GetConnectionString("DataBase")));
builder.Services.AddScoped<IChamadoRepositorio, ChamadoRepositorio>();
builder.Services.AddScoped<IUsuariosRepositorio, UsuariosRepositorio>();

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
