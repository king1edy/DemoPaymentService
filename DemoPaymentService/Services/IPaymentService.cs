using DemoPaymentService.Models;

namespace DemoPaymentService.Services
{
    public interface IPaymentService
    {
        public Task<PaymentResponse> CreditBankAccount(PaymentDTO payment0);

        public Task<PaymentResponse> BillDebitCard(PaymentDTO payment);
    }
}