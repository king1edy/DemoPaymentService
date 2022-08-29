using DemoPaymentService.Models;
using DemoPaymentService.Models.Charge;
using DemoPaymentService.Models.Paystack;
using DemoPaymentService.Models.ResolveAccountNumber;
using DemoPaymentService.Models.Verify;
using Paystack.NetCore.SDK.Models.Charges;

namespace DemoPaymentService.Services
{
    public interface IPaymentService
    {
        public Task<PaystackBankRes> GetBanks(string Country, string? Type);

        #region Single transfer (Send money with the Paystack Transfer API, you can send money to bank accounts and mobile money wallet)

        public Task<ResolveAccountNumberResponse> ResolveAccountNumber(string accountNumber, string bankCode);

        public Task<TransferRecipientResponse> CreateTransferRecipient(TransferRecipientDto transferRecipient);

        public Task<PaystackTransferRes> InitiateTransaction(InitiateTransfer initiateTransfer);

        public Task<object> TransferStatus(TransferStatus transferStatus);

        public Task<FinalizeTransferResponse> FinaliseTransfer(string TransferCode, string OTP);

        #endregion Single transfer (Send money with the Paystack Transfer API, you can send money to bank accounts and mobile money wallet)

        public Task<VerifyPaystackPayment> VerifyPayment(string Reference);

        public Task<string> FinalizePaystackTransfer(string transferRecipt, string otp);

        //public Task<PaymentResponse> CreditBankAccount(PaymentDTO payment0);

        //public Task<PaymentResponse> ChargeCard(PaymentDTO payment);

        public Task<ChargeCustomerResponse> ChargeCustomer(ChargeCustomerReq chargeCustomer);

        public Task<BVNLookUpResponse> BVNLookUp(string BVN);
    }
}