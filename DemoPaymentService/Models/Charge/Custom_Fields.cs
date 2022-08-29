using Newtonsoft.Json;

namespace DemoPaymentService.Models.Charge
{
    public class Custom_Fields
    {
        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("variable_name")]
        public string VariableName { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}