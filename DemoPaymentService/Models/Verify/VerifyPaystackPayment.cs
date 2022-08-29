using Newtonsoft.Json;

namespace DemoPaymentService.Models.Verify
{
    public class VerifyPaystackPayment
    {
        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public VerifyData Data { get; set; }
    }
}