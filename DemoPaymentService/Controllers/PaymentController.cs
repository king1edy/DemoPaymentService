using DemoPaymentService.Models;
using DemoPaymentService.Models.Charge;
using DemoPaymentService.Models.Paystack;
using DemoPaymentService.Models.ResolveAccountNumber;
using DemoPaymentService.Models.Verify;
using DemoPaymentService.Services;
using Microsoft.AspNetCore.Mvc;
using Paystack.NetCore.SDK.Models.Charges;

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
        /// GetBanks
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        [HttpGet("GetBanks")]
        public async Task<ActionResult<PaystackBankRes>> GetBanks(string country, string? type)
        {
            PaystackBankRes paystackBankRes = new();

            paystackBankRes = await _paymentService.GetBanks(country, type);

            return paystackBankRes;
        }

        /// <summary>
        /// ResolveAccountNumber
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <param name="bankCode"></param>
        /// <returns></returns>
        [HttpGet("ResolveAccountNumber")]
        public async Task<ActionResult<ResolveAccountNumberResponse>> ResolveAccountNumber(string accountNumber, string bankCode)
        {
            ResolveAccountNumberResponse resolveAccountNumber = new();
            resolveAccountNumber = await _paymentService.ResolveAccountNumber(accountNumber, bankCode);

            return resolveAccountNumber;
        }

        /// <summary>
        /// CreateTransferRecipient
        /// </summary>
        /// <param name="transferRecipient"></param>
        /// <returns></returns>
        [HttpPost("CreateTransferRecipient")]
        public async Task<ActionResult<TransferRecipientResponse>> CreateTransferRecipient(TransferRecipientDto transferRecipient)
        {
            TransferRecipientResponse transferRecipientResponse = new();
            transferRecipientResponse = await _paymentService.CreateTransferRecipient(transferRecipient);

            return transferRecipientResponse;
        }

        /// <summary>
        /// BillCardPaymentAsync
        /// </summary>
        /// <param name="payment"></param>
        /// <returns></returns>
        //[HttpPost("BillCard")]
        //public async Task<ActionResult<PaymentResponse>> BillCardAsync(PaymentDTO payment)
        //{
        //    PaymentResponse paymentResponse = new();
        //    // Handle card payment here...

        //    CardDetails cardDetails = new()
        //    {
        //    };

        //    try
        //    {
        //        paymentResponse = await _paymentService.ChargeCard(payment);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, ex.Message);
        //    }

        //    return paymentResponse;
        //}

        /// <summary>
        /// ChargeCustomer
        /// </summary>
        /// <param name="chargeCustomer"></param>
        /// <returns></returns>
        [HttpPost("ChargeCustomer")]
        public async Task<ActionResult<ChargeCustomerResponse>> ChargeCustomer(ChargeCustomerReq chargeCustomer)
        {
            ChargeCustomerResponse chargeResponse = new();

            try
            {
                chargeResponse = await _paymentService.ChargeCustomer(chargeCustomer);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }

            return chargeResponse;
        }

        /// <summary>
        /// Initiate Paystack transaction
        /// </summary>
        /// <param name="initiateTransfer"></param>
        /// <returns></returns>
        [HttpPost("InitiateTransaction")]
        public async Task<PaystackTransferRes> InitiateTransaction(InitiateTransfer initiateTransfer)
        {
            PaystackTransferRes paystackTransferRes = new();

            try
            {
                paystackTransferRes = await _paymentService.InitiateTransaction(initiateTransfer);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }

            return paystackTransferRes;
        }

        /// <summary>
        /// Verify Payment
        /// </summary>
        /// <param name="Reference"></param>
        /// <returns></returns>
        [HttpGet("VerifyTransaction")]
        public async Task<VerifyPaystackPayment> VerifyTransaction(string Reference)
        {
            VerifyPaystackPayment paystackPayment = new();

            try
            {
                paystackPayment = await _paymentService.VerifyPayment(Reference);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }

            return paystackPayment;
        }

        /// <summary>
        /// Finalise paystack transfer out
        /// </summary>
        /// <param name="recipient_code"></param>
        /// <returns></returns>
        [HttpPost("FinalisePaystackTransfer")]
        public async Task<PaymentResponse> FinalisePaystackTransfer(string recipient_code, string otp)
        {
            PaymentResponse paymentResponse = new();

            try
            {
                var res = await _paymentService.FinalizePaystackTransfer(recipient_code, otp);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }

            return paymentResponse;
        }

        /// <summary>
        /// CreditBankAccountAsync
        /// </summary>
        /// <param name="paymentObj"></param>
        /// <returns></returns>
        //[HttpPost("CreditBankAccountAsync")]
        //public async Task<ActionResult<PaymentResponse>> CreditBankAccountAsync(PaymentDTO paymentObj)
        //{
        //    PaymentResponse paymentResponse = new();

        //    try
        //    {
        //        paymentResponse = await _paymentService.CreditBankAccount(paymentObj);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, ex.Message);
        //    }

        //    return paymentResponse;
        //}

        /// <summary>
        /// BVNLookUpAsync
        /// </summary>
        /// <param name="BVN"></param>
        /// <returns></returns>
        [HttpPost("BVNLookUpAsync")]
        public async Task<ActionResult<BVNLookUpResponse>> BVNLookUpAsync(string BVN)
        {
            BVNLookUpResponse response = new();

            try
            {
                response = await _paymentService.BVNLookUp(BVN);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }

            return response;
        }
    }
}