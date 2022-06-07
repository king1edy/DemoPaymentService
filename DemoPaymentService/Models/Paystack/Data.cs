using Newtonsoft.Json;

namespace DemoPaymentService.Models.Paystack
{
    public class Data
    {
        [JsonProperty("transfersessionid")]
        public object[] Transfersessionid { get; set; }

        [JsonProperty("domain")]
        public string Domain { get; set; }

        [JsonProperty("amount")]
        public long Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("reference")]
        public string Reference { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("source_details")]
        public object SourceDetails { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("failures")]
        public object Failures { get; set; }

        [JsonProperty("transfer_code")]
        public string TransferCode { get; set; }

        [JsonProperty("titan_code")]
        public object TitanCode { get; set; }

        [JsonProperty("transferred_at")]
        public object TransferredAt { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("integration")]
        public long Integration { get; set; }

        [JsonProperty("request")]
        public long Request { get; set; }

        [JsonProperty("recipient")]
        public long Recipient { get; set; }

        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
