using Newtonsoft.Json;

public class Bank
{
    [JsonProperty("code")]
    public string Code { get; set; }

    [JsonProperty("account_number")]
    public string AccountNumber { get; set; } = string.Empty;
}