using Newtonsoft.Json;

namespace DemoPaymentService.Models
{
    public class BVNLookUpResponse
    {
        [JsonProperty("statue")]
        public bool Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public List<MonoData> Data { get; set; }
    }

    public class Data
    {
        [JsonProperty("bvn")]
        public string BVN { get; set; }

        [JsonProperty("is_blacklisted")]
        public bool IsBlacklisted { get; set; }

        [JsonProperty("account_number")]
        public bool AccountNumber { get; set; }

        [JsonProperty("first_name")]
        public bool FirstName { get; set; }

        [JsonProperty("middle_name")]
        public bool MiddleName { get; set; }

        [JsonProperty("last_name")]
        public bool LastName { get; set; }
    }

    public class MonoData
    {
        public string accountNumber { get; set; }
        public Institution institution { get; set; }
    }

    public class Institution
    {
        public string _id { get; set; }
        public string name { get; set; }
        public string bankCode { get; set; }
        public string icon { get; set; }
    }
}