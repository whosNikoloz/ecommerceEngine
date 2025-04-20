using EcommerceEngine.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceEngine.Domain.Entities
{
    public class Order : BaseEntity
    {
        public int UserId { get; set; }
        public decimal TotalAmount { get; set; }
        public OrderStatus Status { get; set; }
        public string ShippingAddress { get; set; }
        public string BillingAddress { get; set; }
        public string TrackingNumber { get; set; }
        public string Notes { get; set; }

        // Navigation properties
        public User User { get; set; }
        public ICollection<OrderItem> Items { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public Shipment Shipment { get; set; }

        public Order()
        {
            Items = new List<OrderItem>();
            Payments = new List<Payment>();
            Status = OrderStatus.Pending;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
