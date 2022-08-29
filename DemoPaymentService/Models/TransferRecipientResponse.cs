using Newtonsoft.Json;

namespace DemoPaymentService.Models
{
    public class TransferRecipientResponse
    {
        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public List<TransferRecipientData> Data { get; set; }
    }
}