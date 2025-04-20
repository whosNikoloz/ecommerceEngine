using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceEngine.Domain.Entities
{
    public class PaymentTransaction : BaseEntity
    {
        public int PaymentId { get; set; }
        public string TransactionId { get; set; }
        public string RawRequest { get; set; }
        public string RawResponse { get; set; }
        public bool IsSuccessful { get; set; }
        public string ErrorMessage { get; set; }

        // Navigation properties
        public Payment Payment { get; set; }
    }
}
