namespace EcommerceEngine.Application.DTOs.Payments
{
    public class PaymentResponseDto
    {
        public int PaymentId { get; set; }
        public string Status { get; set; }
        public DateTime ProcessedAt { get; set; }
        public string TransactionId { get; set; }
    }
}