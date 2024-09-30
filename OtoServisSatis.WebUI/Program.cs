using OtoServisSatis.Data;
using OtoServisSatis.Service.Abstract;
using OtoServisSatis.Service.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;  //cookie bazl� k�t�phane

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DatabaseContext>();

builder.Services.AddTransient(typeof(IService<>), typeof(Service<>)); //IServices yap�s�n� kullanmabilmek i�in AddTransient olarak ekledik.
builder.Services.AddTransient<ICarService, CarService>();
builder.Services.AddTransient<IUserService, UserService>();


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
{
    x.LoginPath = "/Account/Login"; //admin ekran�na nereden girilecek
    x.AccessDeniedPath = "/AccessDenied"; //yetkisiz eri�imleri y�nlendirme
    x.LogoutPath = "/Account/Logout"; //��k�� i�in
    x.Cookie.Name = "User"; //olu�acak cookie ad�
    x.Cookie.MaxAge = TimeSpan.FromDays(7); //giri� yapan ki�inin cookie'si 7 g�n boyunca devam etsin.
    x.Cookie.IsEssential = true; //
}); //Cookie bazl� Authentication servisini ekledik.

builder.Services.AddAuthorization(x => //yetkilerin altyap�lar�n� yapt�k ve art�k controller'da yetki d�ei�ikliklerine haz�r�z
{
    x.AddPolicy("AdminPolicy", policy => policy.RequireClaim(ClaimTypes.Role, "Admin"));
    x.AddPolicy("UserPolicy", policy => policy.RequireClaim(ClaimTypes.Role, "Admin", "User"));
    x.AddPolicy("CustomerPolicy", policy => policy.RequireClaim(ClaimTypes.Role, "Admin", "User", "Customer"));

});
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

app.UseAuthentication(); //uygulamada Authentication oldu�u i�in ekledik. Authorization'dan �nce eklememiz gerekiyor.
app.UseAuthorization();

app.MapControllerRoute(
            name: "admin",
            pattern: "{area:exists}/{controller=Main}/{action=Index}/{id?}"
          );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
