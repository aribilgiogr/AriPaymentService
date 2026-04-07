using System.ComponentModel.DataAnnotations;

namespace Core.Concretes.DTOs
{
    public record RefundRequest
    {
        [Required]
        public string Provider { get; init; } = null!;

        [Range(0.01, double.MaxValue)]
        public decimal? Amount { get; init; }

        [Required]
        public string TransactionId { get; init; } = null!;
        public string? Reason { get; init; }
        public Dictionary<string, object>? MetaData { get; init; }
    }
}
