using Business.Factories;
using Business.Providers;
using Business.Services;
using Core.Abstracts;
using Microsoft.Extensions.DependencyInjection;

namespace Business
{
    public static class IOC
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {

            services.AddScoped<IPaymentProviderFactory, PaymentProviderFactory>();
            services.AddScoped<IPaymentService, PaymentService>();

            // Payment providers:
            services.AddScoped<MockPay1>();
            services.AddScoped<MockPay2>();

            return services;
        }
    }
}
