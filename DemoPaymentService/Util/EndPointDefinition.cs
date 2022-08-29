namespace DemoPaymentService.Util
{
    public class EndPointDefinition
    {
        public static readonly string PAYSTACK_URL = Misc.Payment_URL();

        public static readonly string LIST_BANK = $"{PAYSTACK_URL}/bank";
        public static readonly string RESOLVE_ACCOUNT = $"{PAYSTACK_URL}/bank/resolve";
        public static readonly string LIST_TRANSACTION = $"{PAYSTACK_URL}/transaction";
        public static readonly string GET_TRANSACTION = $"{PAYSTACK_URL}/transaction/";
        public static readonly string INITIATE_TRANSACTION = $"{PAYSTACK_URL}/transaction/initialize";
        public static readonly string VERIFY_TRANSACTION = $"{PAYSTACK_URL}/transaction/verify/";
        public static readonly string CHECK = $"{PAYSTACK_URL}/transaction/check_authorization";
        public static readonly string TRANSACTION_TIMELINE = $"{PAYSTACK_URL}/transaction/timeline/id";
        public static readonly string TRANSACTION_TOTAL = $"{PAYSTACK_URL}/transaction/totals";
        public static readonly string EXPORT_TRANSACTION = $"{PAYSTACK_URL}/transaction/export";

        public static readonly string TRANSFER_RECIPIENT = $"{PAYSTACK_URL}/transferrecipient";
        public static readonly string FINALIZE_TRANSFER = $"{PAYSTACK_URL}/transfer/finalize_transfer";

        public static readonly string CHARGE = $"{PAYSTACK_URL}/charge";
        public static readonly string CHARGE_AUTHORISATION = $"{PAYSTACK_URL}/transaction/charge_authorization";

        public static readonly string PARTIAL_DEBIT = $"{PAYSTACK_URL}/transaction/partial_debit";
        public static readonly string SPLIT_TRANSACTION = $"{PAYSTACK_URL}/transaction/split";
    }
}