using Core.Concretes.DTOs;

namespace Core.Abstracts
{
    public interface IPaymentProvider
    {
        string ProviderName { get; }
        Task<PaymentResponse> ProcessPaymentAsync(PaymentRequest request);
        Task<RefundResponse> ProcessRefundAsync(RefundRequest request);
        Task<PaymentResponse> GetPaymentStatusAsync(string transactionId);
    }
}
