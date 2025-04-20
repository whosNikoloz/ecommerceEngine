using Microsoft.Extensions.Logging;
using System.Net.Mail;
using System.Net;

namespace ecommerceEngine.Infrastructure.Email
{
    public class EmailService
    {
        private readonly ILogger<EmailService> _logger;
        private readonly string _smtpHost;
        private readonly int _smtpPort;
        private readonly string _smtpUsername;
        private readonly string _smtpPassword;
        private readonly string _fromEmail;
        private readonly string _fromName;

        public EmailService(ILogger<EmailService> logger, Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            _logger = logger;

            _smtpHost = configuration["EmailSettings:SmtpHost"];
            _smtpPort = int.Parse(configuration["EmailSettings:SmtpPort"]);
            _smtpUsername = configuration["EmailSettings:SmtpUsername"];
            _smtpPassword = configuration["EmailSettings:SmtpPassword"];
            _fromEmail = configuration["EmailSettings:FromEmail"];
            _fromName = configuration["EmailSettings:FromName"];
        }

        public async Task SendEmailAsync(string to, string subject, string body)
        {
            try
            {
                var message = new MailMessage
                {
                    From = new MailAddress(_fromEmail, _fromName),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                };

                message.To.Add(to);

                using var client = new SmtpClient(_smtpHost, _smtpPort)
                {
                    Credentials = new NetworkCredential(_smtpUsername, _smtpPassword),
                    EnableSsl = true
                };

                await client.SendMailAsync(message);

                _logger.LogInformation("Email sent successfully to {Email} with subject {Subject}", to, subject);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending email to {Email} with subject {Subject}", to, subject);
                throw;
            }
        }

        public async Task SendOrderConfirmationEmailAsync(string to, string customerName, int orderId, decimal amount)
        {
            var templatePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "EmailTemplates", "OrderConfirmation.html");

            if (!File.Exists(templatePath))
            {
                _logger.LogError("Order confirmation email template not found at path: {Path}", templatePath);
                return;
            }

            var templateContent = await File.ReadAllTextAsync(templatePath);

            var emailBody = templateContent
                .Replace("{CustomerName}", customerName)
                .Replace("{OrderId}", orderId.ToString())
                .Replace("{OrderAmount}", amount.ToString("C"))
                .Replace("{OrderDate}", DateTime.UtcNow.ToString("yyyy-MM-dd"));

            await SendEmailAsync(to, $"Order Confirmation #{orderId}", emailBody);
        }

        public async Task SendShipmentNotificationEmailAsync(string to, string customerName, int orderId, string trackingNumber)
        {
            var templatePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "EmailTemplates", "ShipmentNotification.html");

            if (!File.Exists(templatePath))
            {
                _logger.LogError("Shipment notification email template not found at path: {Path}", templatePath);
                return;
            }

            var templateContent = await File.ReadAllTextAsync(templatePath);

            var emailBody = templateContent
                .Replace("{CustomerName}", customerName)
                .Replace("{OrderId}", orderId.ToString())
                .Replace("{TrackingNumber}", trackingNumber)
                .Replace("{ShipmentDate}", DateTime.UtcNow.ToString("yyyy-MM-dd"));

            await SendEmailAsync(to, $"Your Order #{orderId} Has Been Shipped", emailBody);
        }
    }
}
