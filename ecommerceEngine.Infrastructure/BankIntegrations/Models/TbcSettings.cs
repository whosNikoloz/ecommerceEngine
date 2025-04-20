using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerceEngine.Infrastructure.BankIntegrations.Models
{
    public class TbcSettings
    {
        public string MerchantId { get; set; }
        public string CertPath { get; set; }
        public string CertPassword { get; set; }
        public string ApiUrl { get; set; }
        public string ReturnUrl { get; set; }
        public string NotifyUrl { get; set; }
    }
}
