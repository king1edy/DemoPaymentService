using Newtonsoft.Json;

namespace DemoPaymentService.Models.Charge
{
    public class ChargeData
    {
        [JsonProperty("amount")]
        public long Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("transaction_date")]
        public DateTimeOffset TransactionDate { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("reference")]
        public string Reference { get; set; }

        [JsonProperty("domain")]
        public string Domain { get; set; }

        [JsonProperty("metadata")]
        public Metadata Metadata { get; set; }

        [JsonProperty("gateway_response")]
        public string GatewayResponse { get; set; }

        [JsonProperty("message")]
        public object Message { get; set; }

        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("ip_address")]
        public string IpAddress { get; set; }

        [JsonProperty("log")]
        public object Log { get; set; }

        [JsonProperty("fees")]
        public long Fees { get; set; }

        [JsonProperty("authorization")]
        public ChargeAuthorization Authorization { get; set; }

        [JsonProperty("customer")]
        public Customer Customer { get; set; }

        [JsonProperty("plan")]
        public object Plan { get; set; }
    }
}