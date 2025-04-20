namespace EcommerceEngine.Domain.Enums
{
    public enum ShipmentStatus
    {
        Pending = 0,
        Processing = 1,
        Packed = 2,
        Shipped = 3,
        InTransit = 4,
        OutForDelivery = 5,
        Delivered = 6,
        Failed = 7,
        Returned = 8
    }
}