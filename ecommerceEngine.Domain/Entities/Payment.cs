using EcommerceEngine.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceEngine.Domain.Entities
{
    public class Payment : BaseEntity
    {
        public int OrderId { get; set; }
        public string TransactionId { get; set; }
        public PaymentMethod Method { get; set; }
        public decimal Amount { get; set; }
        public PaymentStatus Status { get; set; }
        public DateTime Timestamp { get; set; }
        public string PaymentIntentId { get; set; }

        // Navigation properties
        public Order Order { get; set; }

        public Payment()
        {
            Status = PaymentStatus.Pending;
            Timestamp = DateTime.UtcNow;
        }
    }
}
