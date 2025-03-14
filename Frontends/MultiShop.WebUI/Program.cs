using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using MultiShop.WebUI.Handlers;
using MultiShop.WebUI.Services;
using MultiShop.WebUI.Services.Concrete;
using MultiShop.WebUI.Services.Interfaces;
using MultiShop.WebUI.Settings;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddCookie(JwtBearerDefaults.AuthenticationScheme, opt =>
{
    opt.LoginPath = "/Login/Index";
    opt.LoginPath = "/login/LogOut";
    opt.AccessDeniedPath="/Pages/AccessDenied";
    opt.Cookie.HttpOnly = true;
    opt.Cookie.SameSite=SameSiteMode.Strict;
    opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
    opt.Cookie.Name = "MultiSjopJwt";
});
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, opt =>
{
    opt.LoginPath = "/Login/Index";
    opt.ExpireTimeSpan = TimeSpan.FromDays(5);
    opt.Cookie.Name = "MultiShopCookie";
    opt.SlidingExpiration = true;
});
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ILoginService,LoginService>();
builder.Services.AddHttpClient<IIdentityService,IdentityService>();
builder.Services.AddHttpClient();
builder.Services.AddControllersWithViews();
builder.Services.Configure<ClientSettings>(
    builder.Configuration.GetSection("ClientSettings"));
builder.Services.Configure<ServiceApiSettings>(
	builder.Configuration.GetSection("ServiceApiSettings"));
builder.Services.AddScoped<ResourceOwnerPasswordTokenHandler>();
var values = builder.Configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
builder.Services.AddHttpClient<IUserService, UserService>(opt =>
{
    opt.BaseAddress = new Uri(values.IdentityServerUrl);
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});
app.Run();
