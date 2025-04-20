using EcommerceEngine.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceEngine.Domain.Entities
{
    public class Shipment : BaseEntity
    {
        public int OrderId { get; set; }
        public string Carrier { get; set; }
        public string TrackingNumber { get; set; }
        public ShipmentStatus Status { get; set; }
        public DateTime? ShippedDate { get; set; }
        public DateTime? EstimatedDeliveryDate { get; set; }
        public DateTime? DeliveredDate { get; set; }

        // Navigation properties
        public Order Order { get; set; }

        public Shipment()
        {
            Status = ShipmentStatus.Pending;
        }
    }
}
