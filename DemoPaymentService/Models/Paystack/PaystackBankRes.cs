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
        public List<Datum> Data { get; set; }

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
        public string Code { get; set; }

        [JsonProperty("longcode")]
        public string Longcode { get; set; }

        [JsonProperty("gateway")]
        public Gateway? Gateway { get; set; }

        [JsonProperty("pay_with_bank")]
        public bool PayWithBank { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("is_deleted")]
        public bool? IsDeleted { get; set; }

        [JsonProperty("country")]
        public Country Country { get; set; }

        [JsonProperty("currency")]
        public Currency Currency { get; set; }

        [JsonProperty("type")]
        public TypeEnum Type { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("createdAt")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTimeOffset UpdatedAt { get; set; }
    }

    public enum Country { Nigeria };

    public enum Currency { Ngn };

    public enum Gateway { Digitalbankmandate, Emandate, Empty, Ibank };

    public enum TypeEnum { Empty, Nuban };

    public partial class PaystackBankRes
    {
        public static PaystackBankRes FromJson(string json) => JsonConvert.DeserializeObject<PaystackBankRes>(json, Converter.Settings);
    }
}