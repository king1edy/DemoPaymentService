using DemoPaymentService.Models;
using Paystack.NetCore.SDK.Interfaces;
using Paystack.NetCore.SDK.Transfers;
using Paystack.NetCore.SDK.Charges;
using DemoPaymentService.Models.Paystack;
using Paystack.NetCore.SDK.Customers;
using IdentityPassTestLibrary;
using RestSharp;
using DemoPaymentService.Util;
using Newtonsoft.Json;
using DemoPaymentService.Models.Verify;
using Paystack.NetCore.SDK.Transactions;
using DemoPaymentService.Models.ResolveAccountNumber;
using Paystack.NetCore.SDK.Models.Transfers.Recipient;
using System.Dynamic;
using DemoPaymentService.Models.Charge;
using Paystack.NetCore.SDK.Models.Charges;
using System;

namespace DemoPaymentService.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IConfiguration _configuration;
        private readonly HttpUtil _httpUtil;

        public PaymentService(IConfiguration configuration, HttpUtil httpUtil)
        {
            _configuration = configuration;
            _httpUtil = httpUtil;
        }

        public async Task<PaystackBankRes> GetBanks(string Country, string? Type)
        {
            PaystackBankRes paystackBankRes = new();

            try
            {
                string param = string.IsNullOrWhiteSpace(Type) ? $"Country={Country}" : $"Country={Country}&Type={Type}";
                var res = await _httpUtil.GetRequest(EndPointDefinition.LIST_BANK, null, param);
                paystackBankRes = PaystackBankRes.FromJson(res.Content);
            }
            catch (Exception ex)
            {
                paystackBankRes.Status = false;
                paystackBankRes.Message = ex.Message;
            }

            return paystackBankRes;
        }

        public async Task<ResolveAccountNumberResponse> ResolveAccountNumber(string accountNumber, string bankCode)
        {
            ResolveAccountNumberResponse resolveAccountNumberResponse = new();

            try
            {
                Dictionary<string, string> header = new Dictionary<string, string>();
                header.Add("Authorization", $"Bearer {Misc.Paystack_SECRET_KEY()}");

                string param = $"account_number={accountNumber}&bank_code={bankCode}";
                var response = await _httpUtil.GetRequest(EndPointDefinition.RESOLVE_ACCOUNT, header, param);

                resolveAccountNumberResponse = ResolveAccountNumberResponse.FromJson(response.Content);
            }
            catch (Exception ex)
            {
                resolveAccountNumberResponse.Status = false;
                resolveAccountNumberResponse.Message = ex.Message;
            }

            return resolveAccountNumberResponse;
        }

        public async Task<TransferRecipientResponse> CreateTransferRecipient(TransferRecipientDto transferRecipient)
        {
            TransferRecipientResponse transferRecipientResponse = new();

            try
            {
                Dictionary<string, string> header = new Dictionary<string, string>();
                header.Add("Authorization", $"Bearer {Misc.Paystack_SECRET_KEY()}");

                string body = JsonConvert.SerializeObject(transferRecipient);

                var response = await _httpUtil.PostResquest(EndPointDefinition.TRANSFER_RECIPIENT, header, null, body);
                transferRecipientResponse = JsonConvert.DeserializeObject<TransferRecipientResponse>(response.Content);
            }
            catch (Exception ex)
            {
                transferRecipientResponse.Status = false;
                transferRecipientResponse.Message = ex.Message;
            }
            return transferRecipientResponse;
        }

        public Task<object> TransferStatus(TransferStatus transferStatus)
        {
            dynamic transferStatusResponse = new ExpandoObject();

            try
            {
                if (transferStatus.Event.Equals("Transfer.Success", StringComparison.OrdinalIgnoreCase))
                {
                    transferStatusResponse = new { Status = "Success", Event = transferStatus.Event, Data = transferStatus.Data };
                }

                if (transferStatus.Event.Equals("Transfer.Failed", StringComparison.OrdinalIgnoreCase))
                {
                    transferStatusResponse = new { Status = "Failed", Event = transferStatus.Event, Data = transferStatus.Data };
                }

                if (transferStatus.Event.Equals("Transfer.Reversed", StringComparison.OrdinalIgnoreCase))
                {
                    transferStatusResponse = new { Status = "Reversed", Event = transferStatus.Event, Data = transferStatus.Data };
                }
            }
            catch (Exception ex)
            {
                transferStatusResponse = new { Status = ex.Message, Event = transferStatus.Event, Data = transferStatus.Data };
            }

            return Task.FromResult(transferStatusResponse);
        }

        public async Task<FinalizeTransferResponse> FinaliseTransfer(string TransferCode, string OTP)
        {
            FinalizeTransferResponse finalizeTransferResponse = new FinalizeTransferResponse();

            try
            {
                Dictionary<string, string> header = new Dictionary<string, string>();
                header.Add("Authorization", $"Bearer {Misc.Paystack_SECRET_KEY()}");

                string body = JsonConvert.SerializeObject(finalizeTransferResponse);

                var response = await _httpUtil.PostResquest(EndPointDefinition.FINALIZE_TRANSFER, header, null, body);
                finalizeTransferResponse = JsonConvert.DeserializeObject<FinalizeTransferResponse>(response.Content);
            }
            catch (Exception ex)
            {
                finalizeTransferResponse.Status = false;
                finalizeTransferResponse.Message = ex.Message;
            }
            return finalizeTransferResponse;
        }

        //public async Task<PaymentResponse> ChargeCard(PaymentDTO payment)
        //{
        //    PaymentResponse paymentResponse = new PaymentResponse();

        //    // Bill Debit card here...
        //    PaystackCharge paystackCharge = new(_configuration["Paystack_secret_key"]);
        //    var res = await paystackCharge.ChargeCard(email: payment.Email,
        //        amount: payment.Amount.ToString(),
        //        pin: payment.CardDetails.CardPin,
        //        cvv: payment.CardDetails.CvvCode,
        //        expiry_month: payment.CardDetails.expiry_month,
        //        expiry_year: payment.CardDetails.expiry_year,
        //        number: payment.CardDetails.CardNumber);

        //    paymentResponse.Status = res.Status;
        //    paymentResponse.Message = res.Message;

        //    return paymentResponse;
        //}

        public async Task<ChargeCustomerResponse> ChargeCustomer(ChargeCustomerReq chargeCustomer)
        {
            ChargeCustomerResponse chargeCustomerResponse = new ChargeCustomerResponse();
            ChargeResponse charge = new ChargeResponse();

            try
            {
                Dictionary<string, string> header = new Dictionary<string, string>();
                header.Add("Authorization", $"Bearer {Misc.Paystack_SECRET_KEY()}");

                string body = JsonConvert.SerializeObject(chargeCustomer);

                var response = await _httpUtil.PostResquest(EndPointDefinition.CHARGE, header, null, body);
                if (response.IsSuccessful)
                {
                    chargeCustomerResponse = JsonConvert.DeserializeObject<ChargeCustomerResponse>(response.Content);
                }
            }
            catch (Exception ex)
            {
                chargeCustomerResponse.Status = false;
                chargeCustomerResponse.Message = ex.Message;
            }
            return chargeCustomerResponse;
        }

        //public async Task<PaymentResponse> CreditBankAccount(PaymentDTO paymentDTO)
        //{
        //    // Credit bank account here...
        //    PaystackTransfers transfers = new(_configuration["Paystack_secret_key"]);
        //    var res = await transfers.InitiateTransfer(Convert.ToInt32(paymentDTO.Amount), paymentDTO.SourceBank);
        //    PaymentResponse paymentResponse = new()
        //    {
        //        Status = res.Status,
        //        Message = res.Message,
        //        HasError = res.Status != true
        //    };

        //    return paymentResponse;
        //}

        public async Task<BVNLookUpResponse> BVNLookUp(string BVN)
        {
            BVNLookUpResponse bVNLookUpResponse = new();

            // BVN Lookup here ....
            PaystackCustomer paystackCustomer = new(_configuration["Paystack_secret_key"]);
            var res = await paystackCustomer.ListCustomers();
            var url = "https://api.withmono.com/360view";

            Dictionary<string, string> header = new Dictionary<string, string>();
            header.Add("mono-sec-key", $"{Misc.Mono_SECRET_KEY()}");

            var bodyObj = new { bvn = BVN };
            string body = JsonConvert.SerializeObject(new { bvn = BVN });

            var response = await _httpUtil.PostMonoResquest(url, header, null, body);
            if (response.IsSuccessful)
            {
                bVNLookUpResponse.Status = response.IsSuccessful;
                bVNLookUpResponse = JsonConvert.DeserializeObject<BVNLookUpResponse>(response.Content);
            }

            return bVNLookUpResponse;
        }

        public async Task<PaystackTransferRes> InitiateTransaction(InitiateTransfer initiateTransfer)
        {
            PaystackTransferRes paystackTransferRes = new();

            try
            {
                var amount = Convert.ToInt32(initiateTransfer.Amount * 100);
                Random random = new Random();
                var ramstring = Misc.RandomString(15);
                // Call paystack here...
                PaystackTransaction paystackTransaction = new(Misc.Paystack_SECRET_KEY());
                var response = await paystackTransaction.InitializeTransaction(initiateTransfer.Email, initiateTransfer.Amount, initiateTransfer.FirstName, initiateTransfer.LastName);

                paystackTransferRes.Status = response.Status;
                paystackTransferRes.Message = response.Message;
                paystackTransferRes.Data = response.SubData;

                return paystackTransferRes;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string> FinalizePaystackTransfer(string recipientCode, string otp)
        {
            PaystackTransferRes paystackTransferRes = new();

            try
            {
                //var amount = Convert.ToInt32(initiateTransfer.Amount);
                //Random random = new Random();
                //var ramstring = Misc.RandomString(15);
                // Call paystack here...
                PaystackTransfers paystack = new PaystackTransfers(Misc.Paystack_SECRET_KEY());
                var response = await paystack.FinalizeTransfer(recipientCode, otp);

                //paystackTransferRes.Status = response.Status;
                //paystackTransferRes.Message = response.Message;
                //paystackTransferRes.Data = response.Data;

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<VerifyPaystackPayment> VerifyPayment(string Reference)
        {
            VerifyPaystackPayment verifyPaystackPayment = new();

            Dictionary<string, string> header = new Dictionary<string, string>();
            header.Add("Authorization", $"Bearer {Misc.Paystack_SECRET_KEY()}");

            var res = await _httpUtil.GetRequest($"{EndPointDefinition.VERIFY_TRANSACTION}{Reference}", header, null);
            verifyPaystackPayment = JsonConvert.DeserializeObject<VerifyPaystackPayment>(res.Content);

            return verifyPaystackPayment;
        }
    }
}