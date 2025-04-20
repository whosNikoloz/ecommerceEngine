using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceEngine.Domain.Events
{
    public class OrderPaidEvent
    {
        public int OrderId { get; }
        public DateTime PaidAt { get; }

        public OrderPaidEvent(int orderId, DateTime paidAt)
        {
            OrderId = orderId;
            PaidAt = paidAt;
        }
    }

}
