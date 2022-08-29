using DemoPaymentService.Models.Paystack;
using Newtonsoft.Json;

namespace DemoPaymentService.Models.ResolveAccountNumber
{
    public partial class ResolveAccountNumberResponse
    {
        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public ResolveAccountData Data { get; set; }
    }

    public partial class ResolveAccountNumberResponse
    {
        public static ResolveAccountNumberResponse FromJson(string json) => JsonConvert.DeserializeObject<ResolveAccountNumberResponse>(json, Converter.Settings);
    }
}