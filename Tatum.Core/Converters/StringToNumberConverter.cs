using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Tatum.Core.Converters
{
    public class StringToNumberConverter : JsonConverter<int>
    {
        public override int Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using (var jsonDoc = JsonDocument.ParseValue(ref reader))
            {
                switch (jsonDoc.RootElement.ValueKind)
                {
                    case JsonValueKind.Number:
                        return jsonDoc.RootElement.GetInt32();
                    case JsonValueKind.String:
                        int.TryParse(jsonDoc.RootElement.GetString(), out var number);
                        return number;
                    default:
                        throw new ArgumentException($"Trying to convert invalid value kind to int: {JsonValueKind.String}");
                }
            }
        }

        public override void Write(Utf8JsonWriter writer, int value, JsonSerializerOptions options)
        {
            writer.WriteNumberValue(value);
        }
    }
}