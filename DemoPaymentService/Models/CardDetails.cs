using Newtonsoft.Json;
using static DemoPaymentService.Models.Paystack.Converter;

namespace DemoPaymentService.Models
{
    public class CardDetails
    {
        [JsonProperty("cvv")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Cvv { get; set; }

        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("expiry_month")]
        public string ExpiryMonth { get; set; }

        [JsonProperty("expiry_year")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long ExpiryYear { get; set; }
    }
}