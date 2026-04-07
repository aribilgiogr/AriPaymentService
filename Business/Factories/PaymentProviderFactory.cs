using Business.Providers;
using Core.Abstracts;
using Microsoft.Extensions.DependencyInjection;


namespace Business.Factories
{
    public class PaymentProviderFactory : IPaymentProviderFactory
    {
        private readonly IServiceProvider serviceProvider;

        public PaymentProviderFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IPaymentProvider GetProvider(string providerName)
        {
            return providerName.ToLower() switch
            {
                "mockpay1" => serviceProvider.GetRequiredService<MockPay1>(),
                "mockpay2" => serviceProvider.GetRequiredService<MockPay2>(),
                _ => throw new ArgumentException($"Payment provider '{providerName}' not supported!")
            };
        }
    }
}
