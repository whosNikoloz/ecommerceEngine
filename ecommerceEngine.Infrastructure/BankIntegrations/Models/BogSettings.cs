using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerceEngine.Infrastructure.BankIntegrations.Models
{
    public class BogSettings
    {
        public string MerchantId { get; set; }
        public string ApiKey { get; set; }
        public string ApiUrl { get; set; }
        public string ReturnUrl { get; set; }
        public string NotifyUrl { get; set; }
        public string SecretKey { get; set; }
    }
}
