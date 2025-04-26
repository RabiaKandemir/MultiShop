using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace MultiShop.WebUI.Extensions
{
    public static class AuthenticationExtensions
    {
        public static IServiceCollection ConfigureCustomAuthentication(this IServiceCollection services)
        {
            // JWT ve Cookie Authentication yapılandırmaları
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddCookie(JwtBearerDefaults.AuthenticationScheme, options =>
                {
                    options.LoginPath = "/Login/Index";
                    options.AccessDeniedPath = "/Pages/AccessDenied";
                    options.Cookie.HttpOnly = true;
                    options.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict;
                    options.Cookie.SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.SameAsRequest;
                    options.Cookie.Name = "MultiShopJwt";
                });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
                {
                    options.LoginPath = "/Login/Index";
                    options.ExpireTimeSpan = TimeSpan.FromDays(5);
                    options.Cookie.Name = "MultiShopCookie";
                    options.SlidingExpiration = true;
                });

            // Token yönetimi, HttpContextAccessor vb. eklemeler
            services.AddAccessTokenManagement();
            services.AddHttpContextAccessor();

            return services;
        }
    }
}
