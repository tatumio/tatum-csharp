using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Tatum.CSharp.Core.Converters
{
    public class NotificationAttributesConverter : JsonConverter<Dictionary<string, string>>
    {
        private static ReadOnlyDictionary<string, string> chainNameMappingsRead = new ReadOnlyDictionary<string, string>(
            new Dictionary<string, string>()
            {
                {"ETH", "Ethereum" }
            });
        
        private static ReadOnlyDictionary<string, string> chainNameMappingsWrite = new ReadOnlyDictionary<string, string>(
            new Dictionary<string, string>()
            {
                {"Ethereum", "ETH" }
            });

        public override Dictionary<string, string> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using (var jsonDoc = JsonDocument.ParseValue(ref reader))
            {
                var root = jsonDoc.RootElement;
                var result = new Dictionary<string, string>();
                foreach (var property in root.EnumerateObject())
                {
                    switch (property.Value.ValueKind)
                    {
                        case JsonValueKind.String:
                            if(property.Name == "chain")
                            {
                                result.Add(property.Name, chainNameMappingsRead[property.Value.GetString()]);
                            }
                            else
                            {
                                result.Add(property.Name, property.Value.GetString());
                            }
                            break;
                        case JsonValueKind.Number:
                            result.Add(property.Name, property.Value.GetDecimal().ToString());
                            break;
                        case JsonValueKind.True:
                            result.Add(property.Name, "true");
                            break;
                        case JsonValueKind.False:
                            result.Add(property.Name, "false");
                            break;
                        case JsonValueKind.Null:
                            result.Add(property.Name, null);
                            break;
                        default:
                            throw new JsonException();
                    }
                }
                return result;
            }
        }

        public override void Write(Utf8JsonWriter writer, Dictionary<string, string> value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            
            foreach (var singleValue in value)
            {
                if(singleValue.Key == "interval")
                {
                    writer.WriteNumber(singleValue.Key, Convert.ToInt32(singleValue.Value));
                    continue;
                }

                if (singleValue.Key == "chain")
                {
                    writer.WriteString(singleValue.Key, chainNameMappingsWrite[singleValue.Value]);
                }
                else
                {
                    writer.WriteString(singleValue.Key, singleValue.Value);
                }
            }
            
            writer.WriteEndObject();
        }
    }
}