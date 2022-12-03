
using Microsoft.EntityFrameworkCore;
using Blog.Data.Context;
using Blog.Data.Extensions;
using Blog.Service.Extensitions;
//using Microsoft.EntityFrameworkCore;
//using Blog.Data.Context; bunlar� ekleyebilmek i�in Packeta ten eklemeler yapt�k 






var builder = WebApplication.CreateBuilder(args);


builder.Services.LoadDataLayerExtensions(builder.Configuration);
builder.Services.LoadServicesLayerExtensions();
// Add services to the container.
builder.Services.AddControllersWithViews();
// Veritaban� ba�lant�s� i�in gerekli kodlar� ekleyece�iz, framework var onu packate ten ekleyecez ki �al��s�n 

// Burada bitiyor, DefaultConnection bu isim appsetting.jsondan geldi 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
