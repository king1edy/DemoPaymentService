using Newtonsoft.Json;

namespace DemoPaymentService.Models.Verify
{
    public class History
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("time")]
        public long Time { get; set; }
    }
}