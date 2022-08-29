using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;

namespace DemoPaymentService.Models.Paystack
{
    internal static class Converter
    {
        
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                CountryConverter.Singleton,
                CurrencyConverter.Singleton,
                GatewayConverter.Singleton,
                TypeEnumConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };

        public class ParseStringConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                long l;
                if (string.IsNullOrEmpty(value)) return 0;
                if (Int64.TryParse(value, out l))
                {
                    return l;
                }
                throw new Exception("Cannot unmarshal type long");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (long)untypedValue;
                serializer.Serialize(writer, value.ToString());
                return;
            }

            public static readonly ParseStringConverter Singleton = new ParseStringConverter();
        }

        internal class CountryConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(Country) || t == typeof(Country?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                if (value == "Nigeria")
                {
                    return Country.Nigeria;
                }
                throw new Exception("Cannot unmarshal type Country");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (Country)untypedValue;
                if (value == Country.Nigeria)
                {
                    serializer.Serialize(writer, "Nigeria");
                    return;
                }
                throw new Exception("Cannot marshal type Country");
            }

            public static readonly CountryConverter Singleton = new CountryConverter();
        }

        internal class CurrencyConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(Currency) || t == typeof(Currency?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                if (value == "NGN")
                {
                    return Currency.Ngn;
                }
                throw new Exception("Cannot unmarshal type Currency");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (Currency)untypedValue;
                if (value == Currency.Ngn)
                {
                    serializer.Serialize(writer, "NGN");
                    return;
                }
                throw new Exception("Cannot marshal type Currency");
            }

            public static readonly CurrencyConverter Singleton = new CurrencyConverter();
        }

        internal class GatewayConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(Gateway) || t == typeof(Gateway?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                switch (value)
                {
                    case "":
                        return Gateway.Empty;
                    case "digitalbankmandate":
                        return Gateway.Digitalbankmandate;
                    case "emandate":
                        return Gateway.Emandate;
                    case "ibank":
                        return Gateway.Ibank;
                }
                throw new Exception("Cannot unmarshal type Gateway");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (Gateway)untypedValue;
                switch (value)
                {
                    case Gateway.Empty:
                        serializer.Serialize(writer, "");
                        return;
                    case Gateway.Digitalbankmandate:
                        serializer.Serialize(writer, "digitalbankmandate");
                        return;
                    case Gateway.Emandate:
                        serializer.Serialize(writer, "emandate");
                        return;
                    case Gateway.Ibank:
                        serializer.Serialize(writer, "ibank");
                        return;
                }
                throw new Exception("Cannot marshal type Gateway");
            }

            public static readonly GatewayConverter Singleton = new GatewayConverter();
        }

        internal class TypeEnumConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(TypeEnum) || t == typeof(TypeEnum?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                switch (value)
                {
                    case "":
                        return TypeEnum.Empty;
                    case "nuban":
                        return TypeEnum.Nuban;
                }
                throw new Exception("Cannot unmarshal type TypeEnum");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (TypeEnum)untypedValue;
                switch (value)
                {
                    case TypeEnum.Empty:
                        serializer.Serialize(writer, "");
                        return;
                    case TypeEnum.Nuban:
                        serializer.Serialize(writer, "nuban");
                        return;
                }
                throw new Exception("Cannot marshal type TypeEnum");
            }

            public static readonly TypeEnumConverter Singleton = new TypeEnumConverter();
        }
    }
}