using DemoPaymentService.Models.Charge;
using Newtonsoft.Json;
using static DemoPaymentService.Models.Paystack.Converter;

namespace DemoPaymentService.Models.Charge
{
    public class ChargeCustomerReq
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("metadata")]
        public Metadata Metadata { get; set; }

        [JsonProperty("card")]
        public CardDetails Card { get; set; }

        [JsonProperty("pin")]
        public string Pin { get; set; }
    }
}