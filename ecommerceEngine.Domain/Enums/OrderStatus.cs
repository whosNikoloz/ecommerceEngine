namespace EcommerceEngine.Domain.Enums
{
    public enum OrderStatus
    {
        Pending = 0,
        PendingPayment = 1,
        Paid = 2,
        Processing = 3,
        Packed = 4,
        Shipped = 5,
        Delivered = 6,
        Cancelled = 7,
        Refunded = 8,
        PaymentFailed = 9
    }
}