using DemoPaymentService.Models;
using Paystack.NetCore.SDK.Interfaces;
using Paystack.NetCore.SDK.Transfers;
using Paystack.NetCore.SDK.Charges;
using DemoPaymentService.Models.Paystack;

namespace DemoPaymentService.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IConfiguration _configuration;

        public PaymentService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<PaystackBankRes> GetBankResAsync(string Country)
        {
            PaystackBankRes paystackBankRes = new();

            return paystackBankRes;
        }

        public async Task<PaymentResponse> BillDebitCard(PaymentDTO payment)
        {
            PaymentResponse paymentResponse = new PaymentResponse();

            string cardMonth = payment.CardDetails.ValidUntil.Split("/")[0];
            string cardYear = payment.CardDetails.ValidUntil.Split("/")[1];

            // Bill Debit card here...
            PaystackCharge paystackCharge = new(_configuration["Paystack_secret_key"]);
            var res = await paystackCharge.ChargeCard(email: payment.Email,
                amount: payment.Amount.ToString(),
                pin: payment.CardDetails.CardPin,
                cvv: payment.CardDetails.CvvCode,
                expiry_month: cardMonth,
                expiry_year: cardYear,
                number: payment.CardDetails.CardNumber);

            paymentResponse.Status = res.Status.ToString();
            paymentResponse.Message = res.Message;

            return paymentResponse;
        }

        public async Task<PaymentResponse> CreditBankAccount(PaymentDTO paymentDTO)
        {
            // Credit bank account here...
            PaystackTransfers transfers = new(_configuration["Paystack_secret_key"]);
            var res = await transfers.InitiateTransfer(Convert.ToInt32(paymentDTO.Amount), paymentDTO.SourceBank);
            PaymentResponse paymentResponse = new()
            {
                Status = res.Status.ToString(),
                Message = res.Message,
                HasError = res.Status != true
            };

            return paymentResponse;
        }
    }
}