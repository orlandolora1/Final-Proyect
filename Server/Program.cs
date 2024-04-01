using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Server.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var ConStr = builder.Configuration.GetConnectionString("ConStr");
builder.Services.AddDbContextFactory<LibrosContext>(options => options.UseSqlite(ConStr));

var ConPel = builder.Configuration.GetConnectionString("ConPel");
builder.Services.AddDbContextFactory<OlimpiadasContext>(options => options.UseSqlite(ConPel));

var Base = builder.Configuration.GetConnectionString("Base");
builder.Services.AddDbContextFactory<UsuariosContext>(options => options.UseSqlite(Base));

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
