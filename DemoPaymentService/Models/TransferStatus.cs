using Newtonsoft.Json;

namespace DemoPaymentService.Models
{
    public class TransferStatus
    {
        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("data")]
        public Data Data { get; set; }
    }
}
