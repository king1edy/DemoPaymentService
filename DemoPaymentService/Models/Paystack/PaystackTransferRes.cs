using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DemoPaymentService.Models.Paystack
{
    public partial class PaystackTransferRes
    {
        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public object Data { get; set; }
    }

    public partial class PaystackTransferRes
    {
        public static PaystackTransferRes FromJson(string json) => JsonConvert.DeserializeObject<PaystackTransferRes>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this PaystackTransferRes self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }
}
