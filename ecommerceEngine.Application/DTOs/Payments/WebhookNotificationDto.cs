namespace EcommerceEngine.Application.DTOs.Payments
{
    public class WebhookNotificationDto
    {
        public string EventType { get; set; }
        public DateTime Timestamp { get; set; }
        public string TransactionId { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string Status { get; set; }
    }
}