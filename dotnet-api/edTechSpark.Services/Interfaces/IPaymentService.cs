using edTechSpark.Core.Entities;
using Razorpay.Api;

namespace edTechSpark.Services.Interfaces
{
    public interface IPaymentService : IService<PaymentDetail>
    {
        string CreateOrder(decimal amount, string currency, string receipt);
        int SavePaymentDetails(PaymentDetail model);
        Payment GetPaymentDetails(string paymentId);
        bool VerifySignature(string signature, string orderId, string paymentId);
    }
}
