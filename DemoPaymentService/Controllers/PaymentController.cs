using DemoPaymentService.Models;
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

        /// <summary>
        /// Bill Debit card of customer
        /// </summary>
        /// <param name="payment"></param>
        /// <returns></returns>
        [HttpPost]
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

        [HttpPost]
        public async Task<PaymentResponse> CreditBankAccount(PaymentDTO paymentD)
        {
            PaymentResponse paymentResponse = new PaymentResponse();

            return paymentResponse;
        }
    }
}