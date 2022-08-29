using Newtonsoft.Json;

namespace DemoPaymentService.Models
{
    public class TransferRecipientDto
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("account_number")]
        public string AccountNumber { get; set; }

        [JsonProperty("bank_code")]
        public string BankCode { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }
    }
}