using Newtonsoft.Json;

public class Details
{
    [JsonProperty("authorization_code")]
    public object AuthorizationCode { get; set; }

    [JsonProperty("account_number")]
    public string AccountNumber { get; set; }

    [JsonProperty("account_name")]
    public string AccountName { get; set; }

    [JsonProperty("bank_code")]
    public string BankCode { get; set; }

    [JsonProperty("bank_name")]
    public string BankName { get; set; }
}