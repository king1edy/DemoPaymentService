using Newtonsoft.Json;

namespace DemoPaymentService.Models
{
    public class Meta
    {
        [JsonProperty("calls_this_month")]
        public int CallsThisMonth { get; set; }

        [JsonProperty("free_calls_left")]
        public int FreeCallsLeft { get; set; }

        [JsonProperty("next")]
        public string Next { get; set; }

        [JsonProperty("previous")]
        public string Previous { get; set; }

        [JsonProperty("perPage")]
        public int PerPage { get; set; }
    }
}