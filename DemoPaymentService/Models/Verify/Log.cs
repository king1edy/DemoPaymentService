using Newtonsoft.Json;

namespace DemoPaymentService.Models.Verify
{
    public class Log
    {
        [JsonProperty("start_time")]
        public long StartTime { get; set; }

        [JsonProperty("time_spent")]
        public long TimeSpent { get; set; }

        [JsonProperty("attempts")]
        public long Attempts { get; set; }

        [JsonProperty("errors")]
        public long Errors { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("mobile")]
        public bool Mobile { get; set; }

        [JsonProperty("input")]
        public List<object> Input { get; set; }

        [JsonProperty("history")]
        public List<History> History { get; set; }
    }
}