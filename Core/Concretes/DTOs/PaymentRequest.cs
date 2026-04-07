using System.ComponentModel.DataAnnotations;

namespace Core.Concretes.DTOs
{
    public record PaymentRequest
    {
        [Required]
        public string Provider { get; init; } = null!;

        [Required, Range(0.01, double.MaxValue)]
        public decimal Amount { get; init; }

        [Required]
        public string Currency { get; init; } = "TRY";

        [Required]
        public string OrderNumber { get; init; } = null!;

        public string? Description { get; init; }
        public Dictionary<string, object>? MetaData { get; init; }
    }
}
