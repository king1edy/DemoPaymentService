using DemoPaymentService.Models.Charge;
using Newtonsoft.Json;

namespace DemoPaymentService.Models.Verify
{
    public class VerifyData
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("domain")]
        public string Domain { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("reference")]
        public string Reference { get; set; }

        [JsonProperty("amount")]
        public long Amount { get; set; }

        [JsonProperty("message")]
        public object Message { get; set; }

        [JsonProperty("gateway_response")]
        public string GatewayResponse { get; set; }

        [JsonProperty("paid_at")]
        public DateTimeOffset DataPaidAt { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset DataCreatedAt { get; set; }

        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("ip_address")]
        public string IpAddress { get; set; }

        [JsonProperty("metadata")]
        public Metadata Metadata { get; set; }

        [JsonProperty("log")]
        public Log Log { get; set; }

        [JsonProperty("fees")]
        public long Fees { get; set; }

        [JsonProperty("fees_split")]
        public object FeesSplit { get; set; }

        [JsonProperty("authorization")]
        public ChargeAuthorization Authorization { get; set; }

        [JsonProperty("customer")]
        public ChargeCustomerReq Customer { get; set; }

        [JsonProperty("plan")]
        public object Plan { get; set; }

        [JsonProperty("split")]
        public PlanObject Split { get; set; }

        [JsonProperty("order_id")]
        public object OrderId { get; set; }

        [JsonProperty("paidAt")]
        public DateTimeOffset PaidAt { get; set; }

        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("requested_amount")]
        public long RequestedAmount { get; set; }

        [JsonProperty("pos_transaction_data")]
        public object PosTransactionData { get; set; }

        [JsonProperty("source")]
        public object Source { get; set; }

        [JsonProperty("fees_breakdown")]
        public object FeesBreakdown { get; set; }

        [JsonProperty("transaction_date")]
        public DateTimeOffset TransactionDate { get; set; }

        [JsonProperty("plan_object")]
        public PlanObject PlanObject { get; set; }

        [JsonProperty("subaccount")]
        public PlanObject Subaccount { get; set; }
    }
}