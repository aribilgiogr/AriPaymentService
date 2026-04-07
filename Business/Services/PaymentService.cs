using Core.Abstracts;
using Core.Concretes.DTOs;

namespace Business.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentProviderFactory factory;

        public PaymentService(IPaymentProviderFactory factory)
        {
            this.factory = factory;
        }

        public async Task<PaymentResponse> GetPaymentStatusAsync(string transactionId, string provider)
        {
            var paymentProvider = factory.GetProvider(provider);
            return await paymentProvider.GetPaymentStatusAsync(transactionId);
        }

        public async Task<PaymentResponse> ProcessPaymentAsync(PaymentRequest request)
        {
            var paymentProvider = factory.GetProvider(request.Provider);
            return await paymentProvider.ProcessPaymentAsync(request);
        }

        public async Task<RefundResponse> ProcessRefundAsync(RefundRequest request)
        {
            var paymentProvider = factory.GetProvider(request.Provider);
            return await paymentProvider.ProcessRefundAsync(request);
        }
    }
}
