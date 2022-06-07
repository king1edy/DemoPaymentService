using DemoPaymentService.Models;
using DemoPaymentService.Models.Paystack;
using DemoPaymentService.Services;
using Microsoft.AspNetCore.Mvc;

namespace DemoPaymentService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly ILogger<PaymentController> _logger;
        private readonly IPaymentService _paymentService;

        public PaymentController(ILogger<PaymentController> logger, IPaymentService paymentService)
        {
            _logger = logger;
            _paymentService = paymentService;
        }

        [HttpGet("GetBanks")]
        public async Task<PaystackBankRes> GetBanks(string country)
        {
            PaystackBankRes paystackBankRes = new();

            return paystackBankRes;
        }

        /// <summary>
        /// Bill Debit card of customer
        /// </summary>
        /// <param name="payment"></param>
        /// <returns></returns>
        [HttpPost("BillCardPayment")]
        public async Task<PaymentResponse> BillCardPaymentAsync(PaymentDTO payment)
        {
            PaymentResponse paymentResponse = new();
            // Handle card payment here...
            string DestinationBankId = "";
            string DestinationAcctNum = "";
            double amount = 0;
            CardDetails cardDetails = new()
            {
                CardHolderName = payment.CardDetails.CardHolderName,
                CardNumber = payment.CardDetails.CardNumber,
                CardType = (CardType)payment.CardDetails.CardType,
                CvvCode = payment.CardDetails.CvvCode,
                ValidUntil = payment.CardDetails.ValidUntil
            };

            try
            {
                paymentResponse = await _paymentService.BillDebitCard(payment);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }

            return paymentResponse;
        }

        /// <summary>
        /// Credit bank account with paystack...
        /// </summary>
        /// <param name="paymentObj"></param>
        /// <returns></returns>
        [HttpPost("CreditBankAccountAsync")]
        public async Task<PaymentResponse> CreditBankAccountAsync(PaymentDTO paymentObj)
        {
            PaymentResponse paymentResponse = new();

            try
            {
                paymentResponse = await _paymentService.CreditBankAccount(paymentObj);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }

            return paymentResponse;
        }
    }
}