using KuleliGallery.Shop.UI.Validators.Accounts;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace KuleliGallery.Shop.UI.Configurations
{
    public static class FluentValidationInjection
    {
        public static IServiceCollection AddFluentValidationService(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation()
    .AddFluentValidationClientsideAdapters();

            services.AddValidatorsFromAssemblyContaining(typeof(LoginValidator));

            return services;
        }
    }
}
