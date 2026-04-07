using Core.Abstracts;
using Core.Concretes.DTOs;
using Core.Concretes.enums;

namespace Business.Providers
{
    public class MockPay2 : IPaymentProvider
    {
        public string ProviderName => "MockPay2";

        public async Task<PaymentResponse> GetPaymentStatusAsync(string transactionId)
        {
            // Test için yarım saniye bekletiyoruz.
            await Task.Delay(500);
            return new PaymentResponse
            {
                Status = PaymentStatus.Completed,
                Success = true,
                TransactionId = transactionId
            };
        }

        public async Task<PaymentResponse> ProcessPaymentAsync(PaymentRequest request)
        {
            await Task.Delay(500);
            return new PaymentResponse
            {
                Status = PaymentStatus.Pending,
                Success = true,
                TransactionId = $"MP_2_{Guid.NewGuid()}",
                MetaData = new Dictionary<string, object>
                {
                    ["provider"] = "MockPay 2",
                    ["paymentMethod"] = "redirect",
                    ["amount"] = request.Amount,
                    ["uniqueId"] = request.OrderNumber,
                    ["currencyCode"] = request.Currency.ToUpper()
                },
                PaymentUrl = $"https://example.com/checkoutnow?token=SEC-{Guid.NewGuid()}"
            };
        }

        public async Task<RefundResponse> ProcessRefundAsync(RefundRequest request)
        {
            await Task.Delay(500);
            return new RefundResponse
            {
                Success = request.Amount > 0,
                RefundId = $"MP_R_2_{Guid.NewGuid()}",
                RefundedAmount = request.Amount ?? 0
            };
        }
    }
}
