using Newtonsoft.Json;
using static DemoPaymentService.Models.Paystack.Converter;

namespace DemoPaymentService.Models.Charge
{
    public class ChargeAuthorization
    {
        [JsonProperty("authorization_code")]
        public string AuthorizationCode { get; set; } = string.Empty;

        [JsonProperty("bin")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Bin { get; set; }

        [JsonProperty("last4")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Last4 { get; set; }

        [JsonProperty("exp_month")]
        public string ExpMonth { get; set; }

        [JsonProperty("exp_year")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long ExpYear { get; set; }

        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("card_type")]
        public string CardType { get; set; }

        [JsonProperty("bank")]
        public string Bank { get; set; }

        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

        [JsonProperty("brand")]
        public string Brand { get; set; }

        [JsonProperty("reusable")]
        public bool Reusable { get; set; }

        [JsonProperty("signature")]
        public string Signature { get; set; }

        [JsonProperty("account_name")]
        public string AccountName { get; set; }

        [JsonProperty("receiver_bank_account_number")]
        public object ReceiverBankAccountNumber { get; set; }

        [JsonProperty("receiver_bank")]
        public object ReceiverBank { get; set; }
    }
}