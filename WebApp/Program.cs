using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApp.DAL;
using WebApp.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//DIP
builder.Services.AddDbContext<hospitalDB>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("ConnStr")));

//builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<hospitalDB>();


//builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<KutuphaneDB>();

//Varsay�lan Identity ayarlar� i�in kullan�l�r
//builder.Services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<KutuphaneDB>();

builder.Services.AddIdentity<User, Rol>().AddEntityFrameworkStores<hospitalDB>();


builder.Services.AddMvc();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "AdminPanel",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "UserPanel",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.Use(async (context, next) =>
{
    await next.Invoke();
    if (context.Response.StatusCode == StatusCodes.Status404NotFound)
    {
        context.Response.Redirect("/Identity/Account/Login");
    }
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();
app.Run();