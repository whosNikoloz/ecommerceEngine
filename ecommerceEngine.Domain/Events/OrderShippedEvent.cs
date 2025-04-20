using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceEngine.Domain.Events
{
    public class OrderShippedEvent
    {
        public int OrderId { get; }
        public string TrackingNumber { get; }
        public DateTime ShippedAt { get; }

        public OrderShippedEvent(int orderId, string trackingNumber, DateTime shippedAt)
        {
            OrderId = orderId;
            TrackingNumber = trackingNumber;
            ShippedAt = shippedAt;
        }
    }
}
