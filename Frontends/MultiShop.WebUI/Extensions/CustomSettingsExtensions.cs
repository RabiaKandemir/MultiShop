using MultiShop.WebUI.Settings;

namespace MultiShop.WebUI.Extensions
{
    public static class CustomSettingsExtensions
    {
        public static IServiceCollection ConfigureCustomSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ClientSettings>(configuration.GetSection("ClientSettings"));
            services.Configure<ServiceApiSettings>(configuration.GetSection("ServiceApiSettings"));
            return services;
        }
    }
}
