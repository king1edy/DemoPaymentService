using Newtonsoft.Json;

namespace DemoPaymentService.Models
{
    public class FinalizeTransferResponse
    {
        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; } = string.Empty;

        [JsonProperty("data")]
        public Data Data { get; set; } = new Data();
    }
}

public class Data
{
    [JsonProperty("id")]
    public int Id { get; set; } = 0;

    [JsonProperty("reference")]
    public string Reference { get; set; } = string.Empty;

    [JsonProperty("integration")]
    public int Integration { get; set; } = 0;

    [JsonProperty("domain")]
    public string Domain { get; set; } = string.Empty;

    [JsonProperty("amount")]
    public int Amount { get; set; } = 0;

    [JsonProperty("currency")]
    public string Currency { get; set; } = string.Empty;

    [JsonProperty("source")]
    public string Source { get; set; } = string.Empty;

    [JsonProperty("reason")]
    public string Reason { get; set; } = string.Empty;

    [JsonProperty("recipient")]
    public int Recipient { get; set; } = 0;

    [JsonProperty("status")]
    public string Status { get; set; } = string.Empty;

    [JsonProperty("transfer_code")]
    public string TransferCode { get; set; } = string.Empty;

    [JsonProperty("createdAt")]
    public DateTime CreatedAt { get; set; }

    [JsonProperty("updatedAt")]
    public DateTime UpdatedAt { get; set; }
}