using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.Extensions.Options;
using ecommerceEngine.Infrastructure.BankIntegrations.Models;

namespace EcommerceEngine.Infrastructure.BankIntegrations
{
    public class TbcPaymentService
    {
        private readonly TbcSettings _settings;
        private readonly HttpClient _httpClient;

        public TbcPaymentService(IOptions<TbcSettings> settings, HttpClient httpClient)
        {
            _settings = settings.Value;
            _httpClient = httpClient;
        }

        // Example: Initiate payment, handle webhook, etc.
        // Implement methods as needed for integration
    }
}
