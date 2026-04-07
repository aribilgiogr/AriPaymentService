using Core.Concretes.DTOs;

namespace Core.Abstracts
{
    public interface IPaymentService
    {
        Task<PaymentResponse> ProcessPaymentAsync(PaymentRequest request);
        Task<RefundResponse> ProcessRefundAsync(RefundRequest request);
        Task<PaymentResponse> GetPaymentStatusAsync(string transactionId, string provider);
    }
}
