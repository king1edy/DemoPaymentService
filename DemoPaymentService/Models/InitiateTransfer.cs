using DemoPaymentService.Models.Charge;
using Newtonsoft.Json;

namespace DemoPaymentService.Models
{
    public class InitiateTransfer
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("ref")]
        public string TransactionReference { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("firstname")]
        public string FirstName { get; set; }

        [JsonProperty("lastname")]
        public string LastName { get; set; }

        [JsonProperty("channels")]
        public string Channels { get; set; }

        [JsonProperty("metadata")]
        public Metadata Metadata { get; set; }
    }
}