using Newtonsoft.Json;

namespace DemoPaymentService.Models
{
    public class BankListResponse
    {
        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public Datum Data { get; set; }

        [JsonProperty("meta")]
        public Meta Meta { get; set; }
    }
}

public class Datum
{
    public string name { get; set; }
    public string slug { get; set; }
    public string code { get; set; }
    public string longcode { get; set; }
    public object gateway { get; set; }
    public bool pay_with_bank { get; set; }
    public bool active { get; set; }
    public bool is_deleted { get; set; }
    public string country { get; set; }
    public string currency { get; set; }
    public string type { get; set; }
    public int id { get; set; }
    public DateTime createdAt { get; set; }
    public DateTime updatedAt { get; set; }
}