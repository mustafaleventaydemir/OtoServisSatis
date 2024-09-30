using OtoServisSatis.Data;
using OtoServisSatis.Service.Abstract;
using OtoServisSatis.Service.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;  //cookie bazlý kütüphane

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DatabaseContext>();

builder.Services.AddTransient(typeof(IService<>), typeof(Service<>)); //IServices yapýsýný kullanmabilmek için AddTransient olarak ekledik.
builder.Services.AddTransient<ICarService, CarService>();
builder.Services.AddTransient<IUserService, UserService>();


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
{
    x.LoginPath = "/Account/Login"; //admin ekranýna nereden girilecek
    x.AccessDeniedPath = "/AccessDenied"; //yetkisiz eriþimleri yönlendirme
    x.LogoutPath = "/Account/Logout"; //çýkýþ için
    x.Cookie.Name = "User"; //oluþacak cookie adý
    x.Cookie.MaxAge = TimeSpan.FromDays(7); //giriþ yapan kiþinin cookie'si 7 gün boyunca devam etsin.
    x.Cookie.IsEssential = true; //
}); //Cookie bazlý Authentication servisini ekledik.

builder.Services.AddAuthorization(x => //yetkilerin altyapýlarýný yaptýk ve artýk controller'da yetki dðeiþikliklerine hazýrýz
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

app.UseAuthentication(); //uygulamada Authentication olduðu için ekledik. Authorization'dan önce eklememiz gerekiyor.
app.UseAuthorization();

app.MapControllerRoute(
            name: "admin",
            pattern: "{area:exists}/{controller=Main}/{action=Index}/{id?}"
          );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
