using System.Text.Json;
using System.Text.Json.Serialization;

namespace Tatum.CSharp.Core
{
    public static class TatumSerializerOptions
    {
        public static readonly JsonSerializerOptions Default = new JsonSerializerOptions(){ Converters = { new JsonStringEnumConverter() }};
    }
}