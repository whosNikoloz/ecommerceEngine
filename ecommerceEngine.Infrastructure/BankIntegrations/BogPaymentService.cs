using System.Net.Http;
using Microsoft.Extensions.Options;
using ecommerceEngine.Infrastructure.BankIntegrations.Models;

namespace EcommerceEngine.Infrastructure.BankIntegrations
{
    public class BogPaymentService
    {
        private readonly BogSettings _settings;
        private readonly HttpClient _httpClient;

        public BogPaymentService(IOptions<BogSettings> settings, HttpClient httpClient)
        {
            _settings = settings.Value;
            _httpClient = httpClient;
        }

        // Example: Initiate payment, handle webhook, etc.
        // Implement methods as needed for integration
    }
}
