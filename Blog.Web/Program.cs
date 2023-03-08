using Blog.Data.Context;
using Blog.Data.Extensions;
using Blog.Service.Extensitions;
using Blog.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using NToastNotify;
using Blog.Service.Services.Abstractions;
using Blog.Service.Services.Concrete;
using Blog.Service.Describers;
//using Microsoft.EntityFrameworkCore;
//using Blog.Data.Context; bunlar� ekleyebilmek i�in Packeta ten eklemeler yapt�k 






var builder = WebApplication.CreateBuilder(args);


builder.Services.LoadDataLayerExtensions(builder.Configuration);
builder.Services.LoadServicesLayerExtensions();
builder.Services.AddSession();
// Add services to the container.
builder.Services.AddControllersWithViews()
 .AddNToastNotifyToastr(new ToastrOptions()
 {
     PositionClass = ToastPositions.TopRight,
     TimeOut = 3000

 });




// Veritaban� ba�lant�s� i�in gerekli kodlar� ekleyece�iz, framework var onu packate ten ekleyecez ki �al��s�n 

// Burada bitiyor, DefaultConnection bu isim appsetting.jsondan geldi 


builder.Services.AddIdentity<AppUser, AppRole>(opt =>
{// Burada �ifrtede olmas� gereken b�y�k yaz� k���k yaz� gibi zorunlululalrr� true ve false olarak gereklili�ini ifade ediyoruz. 
    opt.Password.RequireNonAlphanumeric = false;
    opt.Password.RequireLowercase = false;
    opt.Password.RequireUppercase = false;

})
    .AddRoleManager<RoleManager<AppRole>>()
    .AddErrorDescriber<CustomIdentityErrorDescriber>()
    .AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
builder.Services.ConfigureApplicationCookie(config =>
{
    config.LoginPath = new PathString("/Admin/Auth/Login");
    config.LogoutPath = new PathString("/Admin/Auth/Logout");
    config.Cookie = new CookieBuilder
    {
        Name = "MyBlog",
        HttpOnly = true,
        SameSite = SameSiteMode.Strict,
        SecurePolicy = CookieSecurePolicy.SameAsRequest

    };
    config.SlidingExpiration = true;
    config.ExpireTimeSpan = TimeSpan.FromDays(7);
    config.AccessDeniedPath = new PathString("/Admin/Auth/AccessDanied");
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseNToastNotify();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");



app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(name: "Admin", areaName: "Admin", pattern: "Admin/{controller=Home}/{action=Index}/{id?}"
        );
    endpoints.MapDefaultControllerRoute();
});

app.Run();
