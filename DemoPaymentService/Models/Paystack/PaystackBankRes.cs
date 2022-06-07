using Newtonsoft.Json;

namespace DemoPaymentService.Models.Paystack
{
    public partial class PaystackBankRes
    {
        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public Datum[] Data { get; set; }

        [JsonProperty("meta")]
        public Meta Meta { get; set; }
    }
    public partial class Datum
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("code")]
        [JsonConverter(typeof(Converter.ParseStringConverter))]
        public long Code { get; set; }

        [JsonProperty("longcode")]
        public string Longcode { get; set; }

        [JsonProperty("gateway")]
        public object Gateway { get; set; }

        [JsonProperty("pay_with_bank")]
        public bool PayWithBank { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("is_deleted")]
        public bool IsDeleted { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTimeOffset UpdatedAt { get; set; }
    }

    public partial class Meta
    {
        [JsonProperty("next")]
        public string Next { get; set; }

        [JsonProperty("previous")]
        public object Previous { get; set; }

        [JsonProperty("perPage")]
        public long PerPage { get; set; }
    }

    public partial class PaystackBankRes
    {
        public static PaystackBankRes FromJson(string json) => JsonConvert.DeserializeObject<PaystackBankRes>(json, Converter.Settings);
    }
}
