namespace MultiShop.WebUI.Extensions
{
    public static class LocalizationExtensions
    {
        public static IApplicationBuilder ConfigureCustomLocalization(this IApplicationBuilder app)
        {
            var supportedCultures = new[] { "en", "fr", "de", "it", "tr" };
            var localizationOptions = new RequestLocalizationOptions()
                .SetDefaultCulture("tr")
                .AddSupportedCultures(supportedCultures)
                .AddSupportedUICultures(supportedCultures);

            app.UseRequestLocalization(localizationOptions);
            return app;
        }
    }
}
