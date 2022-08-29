using DemoPaymentService.Models.Paystack;
using Newtonsoft.Json;

namespace DemoPaymentService.Models.Charge
{
    public partial class ChargeCustomerResponse
    {
        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public ChargeData Data { get; set; }
    }

    public partial class ChargeCustomerResponse
    {
        public static ChargeCustomerResponse FromJson(string json) => JsonConvert.DeserializeObject<ChargeCustomerResponse>(json, Converter.Settings);
    }
}