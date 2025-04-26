using MultiShop.WebUI.Handlers;
using MultiShop.WebUI.Services;
using MultiShop.WebUI.Services.BasketServices;
using MultiShop.WebUI.Services.CargoServices.CargoCompanieservices;
using MultiShop.WebUI.Services.CargoServices.CargoCompanyServices;
using MultiShop.WebUI.Services.CargoServices.CargoCustomerServices;
using MultiShop.WebUI.Services.CatalogServices.AboutServices;
using MultiShop.WebUI.Services.CatalogServices.BrandServices;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;
using MultiShop.WebUI.Services.CatalogServices.ContactServices;
using MultiShop.WebUI.Services.CatalogServices.FeatureServices;
using MultiShop.WebUI.Services.CatalogServices.FeatureSliderServices;
using MultiShop.WebUI.Services.CatalogServices.OfferDiscountServices;
using MultiShop.WebUI.Services.CatalogServices.ProductDetailServices;
using MultiShop.WebUI.Services.CatalogServices.ProductImageServices;
using MultiShop.WebUI.Services.CatalogServices.ProductImagesServices;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;
using MultiShop.WebUI.Services.CatalogServices.SpecialOfferServices;
using MultiShop.WebUI.Services.CommentServices;
using MultiShop.WebUI.Services.Concrete;
using MultiShop.WebUI.Services.DiscountServices;
using MultiShop.WebUI.Services.Interfaces;
using MultiShop.WebUI.Services.MessageServices;
using MultiShop.WebUI.Services.OrderServices.OrderAddressServices;
using MultiShop.WebUI.Services.OrderServices.OrderOrderingServices;
using MultiShop.WebUI.Services.StatisticServices.CatalogStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.CommentStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.DiscountStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.MessageStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.UserStatisticServices;
using MultiShop.WebUI.Services.UserIndentityServices;
using MultiShop.WebUI.Settings;

namespace MultiShop.WebUI.Extensions
{
    public static class ServiceRegistrationExtensions
    {
        public static IServiceCollection RegisterCustomServices(this IServiceCollection services)
        {
            // Scoped servisler
            services.AddScoped<ILoginService, LoginService>();
            services.AddHttpClient<IIdentityService, IdentityService>();
            services.AddScoped<ResourceOwnerPasswordTokenHandler>();
            services.AddScoped<ClientCredentialTokenHandler>();
            services.AddHttpClient<IClientCredentialTokenService, ClientCredentialTokenService>();

            return services;
        }

        public static IServiceCollection RegisterHttpClients(this IServiceCollection services, IConfiguration configuration)
        {
            var settings = configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();

            // Resource Owner Password Clients
            RegisterResourceOwnerClient<IUserService, UserService>(services, settings.IdentityServerUrl);
            RegisterResourceOwnerClient<IBasketService, BasketService>(services, $"{settings.OcelotUrl}/{settings.Basket.Path}");
            RegisterResourceOwnerClient<IDiscountService, DiscountService>(services, $"{settings.OcelotUrl}/{settings.Discount.Path}");
            RegisterResourceOwnerClient<IOrderAddressService, OrderAddressService>(services, $"{settings.OcelotUrl}/{settings.Order.Path}");
            RegisterResourceOwnerClient<IOrderOrderingService, OrderOrderingService>(services, $"{settings.OcelotUrl}/{settings.Order.Path}");
            RegisterResourceOwnerClient<IMessageService, MessageService>(services, $"{settings.OcelotUrl}/{settings.Message.Path}");
            RegisterResourceOwnerClient<IUserIdentityService, UserIdentityService>(services, settings.IdentityServerUrl);
            RegisterResourceOwnerClient<IUserStatisticService, UserStatisticService>(services, settings.IdentityServerUrl);
            RegisterResourceOwnerClient<ICargoCompanyService, CargoCompanyService>(services, $"{settings.OcelotUrl}/{settings.Cargo.Path}");
            RegisterResourceOwnerClient<ICargoCustomerService, CargoCustomerService>(services, $"{settings.OcelotUrl}/{settings.Cargo.Path}");
            RegisterResourceOwnerClient<ICatalogStatisticService, CatalogStatisticService>(services, $"{settings.OcelotUrl}/{settings.Catalog.Path}");
            RegisterResourceOwnerClient<ICommentStatisticService, CommentStatisticService>(services, $"{settings.OcelotUrl}/{settings.Comment.Path}");
            RegisterResourceOwnerClient<IDiscountStatisticService, DiscountStatisticService>(services, $"{settings.OcelotUrl}/{settings.Discount.Path}");
            RegisterResourceOwnerClient<IMessageStatisticService, MessageStatisticService>(services, $"{settings.OcelotUrl}/{settings.Message.Path}");

            // Client Credential Clients
            RegisterClientCredentialClient<ICategoryService, CategoryService>(services, $"{settings.OcelotUrl}/{settings.Catalog.Path}");
            RegisterClientCredentialClient<IProductService, ProductService>(services, $"{settings.OcelotUrl}/{settings.Catalog.Path}");
            RegisterClientCredentialClient<ISpecialOfferService, SpecialOfferService>(services, $"{settings.OcelotUrl}/{settings.Catalog.Path}");
            RegisterClientCredentialClient<IFeatureSliderService, FeatureSliderService>(services, $"{settings.OcelotUrl}/{settings.Catalog.Path}");
            RegisterClientCredentialClient<IFeatureService, FeatureService>(services, $"{settings.OcelotUrl}/{settings.Catalog.Path}");
            RegisterClientCredentialClient<IOfferDiscountService, OfferDiscountService>(services, $"{settings.OcelotUrl}/{settings.Catalog.Path}");
            RegisterClientCredentialClient<IBrandService, BrandService>(services, $"{settings.OcelotUrl}/{settings.Catalog.Path}");
            RegisterClientCredentialClient<IAboutService, AboutService>(services, $"{settings.OcelotUrl}/{settings.Catalog.Path}");
            RegisterClientCredentialClient<IProductImageService, ProductImageService>(services, $"{settings.OcelotUrl}/{settings.Catalog.Path}");
            RegisterClientCredentialClient<IProductDetailService, ProductDetailService>(services, $"{settings.OcelotUrl}/{settings.Catalog.Path}");
            RegisterClientCredentialClient<ICommentService, CommentService>(services, $"{settings.OcelotUrl}/{settings.Comment.Path}");
            RegisterClientCredentialClient<IContactService, ContactService>(services, $"{settings.OcelotUrl}/{settings.Catalog.Path}");

            return services;
        }

        private static void RegisterClientCredentialClient<TClient, TImplementation>(IServiceCollection services, string baseAddress)
            where TClient : class
            where TImplementation : class, TClient
        {
            services.AddHttpClient<TClient, TImplementation>(options =>
            {
                options.BaseAddress = new Uri(baseAddress);
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();
        }

        private static void RegisterResourceOwnerClient<TClient, TImplementation>(IServiceCollection services, string baseAddress)
            where TClient : class
            where TImplementation : class, TClient
        {
            services.AddHttpClient<TClient, TImplementation>(options =>
            {
                options.BaseAddress = new Uri(baseAddress);
            }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();
        }
    }
}