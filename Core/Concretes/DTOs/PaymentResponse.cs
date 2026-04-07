using Core.Concretes.enums;

namespace Core.Concretes.DTOs
{
    public record PaymentResponse
    {
        public bool Success { get; init; }
        public string? TransactionId { get; init; }
        public string? PaymentUrl { get; init; }
        public string? ErrorMessage { get; init; }
        public Dictionary<string, object>? MetaData { get; init; }
        public PaymentStatus Status { get; init; }
    }
}
