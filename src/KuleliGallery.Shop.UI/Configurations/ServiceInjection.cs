using KuleliGallery.Shop.UI.Services.Abstraction;
using KuleliGallery.Shop.UI.Validators.Accounts;
using FluentValidation;
using FluentValidation.AspNetCore;
using KuleliGalleryi.Shop.UI.Services.Implementation;

namespace KuleliGallery.Shop.UI.Configurations
{
    public static class ServiceInjection
    {
        public static IServiceCollection AddDIServices(this IServiceCollection services)
        {
            services.AddScoped<IRestService, RestService>();
            
            return services;
        }
    }
}
