using MultiShop.WebUI.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Ayarlar, Kimlik Doğrulama, Servis ve HttpClient kayıtları
builder.Services
       .ConfigureCustomSettings(builder.Configuration)
       .ConfigureCustomAuthentication()
       .RegisterCustomServices()
       .RegisterHttpClients(builder.Configuration);

builder.Services.AddLocalization(options =>
{
    options.ResourcesPath = "Resources";
});
builder.Services.AddMvc()
                .AddViewLocalization(Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Middleware Pipeline
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

app.ConfigureCustomLocalization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
});

app.Run();
