
using Serilog;

namespace EcommerceEngine.Infrastructure.Logging
{
    public class LoggingService
    {
        private readonly ILogger _logger;

        public LoggingService()
        {
            _logger = Serilog.Log.ForContext<LoggingService>();
        }

        public void LogInformation(string message, params object[] propertyValues)
        {
            _logger.Information(message, propertyValues);
        }

        public void LogWarning(string message, params object[] propertyValues)
        {
            _logger.Warning(message, propertyValues);
        }

        public void LogError(Exception exception, string message, params object[] propertyValues)
        {
            _logger.Error(exception, message, propertyValues);
        }

        public void LogCritical(Exception exception, string message, params object[] propertyValues)
        {
            _logger.Fatal(exception, message, propertyValues);
        }

        public void LogPaymentAttempt(int orderId, string provider, bool success, string transactionId)
        {
            _logger.Information(
                "Payment {Status} for Order {OrderId} via {Provider}. Transaction ID: {TransactionId}",
                success ? "Successful" : "Failed",
                orderId,
                provider,
                transactionId);
        }

        public void LogOrderStatusChange(int orderId, string oldStatus, string newStatus)
        {
            _logger.Information(
                "Order {OrderId} status changed from {OldStatus} to {NewStatus}",
                orderId,
                oldStatus,
                newStatus);
        }
    }
}
