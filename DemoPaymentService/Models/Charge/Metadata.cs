using Newtonsoft.Json;

namespace DemoPaymentService.Models.Charge
{
    public class Metadata
    {
        [JsonProperty("custom_fields")]
        public Custom_Fields[] CustomFields { get; set; }

        [JsonProperty("cancel_action")]
        public Uri CancelAction { get; set; }
    }
}