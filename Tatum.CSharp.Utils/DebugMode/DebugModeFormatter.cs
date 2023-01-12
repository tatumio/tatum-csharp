using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Tatum.CSharp.Utils.DebugMode
{
    internal static class DebugModeFormatter
    {
                
        private const string Redacted = "******";
        
        private const int MaxLength = 2000;

        private static readonly string[] SensitiveFieldList = new[]
        {
            "fromPrivateKey",
            "fromSecret",
            "privateKey",
            "key",
            "secret",
            "mnemonic",
            "priv"
        };
        
        internal static async Task<StringBuilder> PrepareRequestLog(HttpRequestMessage request, bool hideSecrets)
        {
            var sb = new StringBuilder();

            sb.AppendLine($">>>>>>>>>>>>>>> Tatum API REQUEST TestNet >>>>>>>>>>>>>>>>>");

            var requestUri = request.RequestUri?.ToString();
            
            if(hideSecrets)
            {
                requestUri = GetObfuscatedRequestUri(request);
            }
            
            sb.AppendLine($"curl -i -X {request.Method.Method} '{requestUri}' \\");

            ReplaceDebugUserAgent(request);

            foreach (var header in request.Headers)
            {
                var headerValue = header.Value;
                
                if(hideSecrets)
                {
                    headerValue = GetObfuscatedHeaderValue(header);
                }
                
                sb.AppendLine($"-H '{header.Key}: {string.Join(",", headerValue)}' \\");
            }

            if (request.Content != null)
            {
                var content = await request.Content.ReadAsStringAsync();

                var mediaType = request.Content.Headers.ContentType.MediaType;

                switch (mediaType)
                {
                    case "application/octet-stream":
                        content = "( binary data )";
                        break;
                    case "multipart/form-data":
                        if(content.Contains("application/octet-stream"))
                        {
                            content = "( binary data )";
                        }
                        break;
                    case "application/json":
                        if(hideSecrets)
                        {
                            content = GetObfuscatedContent(JToken.Parse(content), SensitiveFieldList).ToString(Formatting.Indented);
                        } 
                        break;
                }

                sb.AppendLine($"-H 'Content-Type: {mediaType}' \\");
                sb.AppendLine($"-d '{Truncate(content)}'");
            }

            sb.AppendLine($">>>>>>>>>>>>>>> /Tatum API REQUEST TestNet >>>>>>>>>>>>>>>>>");
            
            return sb;
        }

        private static IEnumerable<string> GetObfuscatedHeaderValue(KeyValuePair<string, IEnumerable<string>> header)
        {
            var headerValues = new List<string>();
            
            if (header.Key == "x-api-key" && header.Value.Any())
            {
                foreach (var headerValue in header.Value)
                {
                    var headerParts = headerValue.Split('_');
                    var headerFirstPart = headerParts.First();
                    var headerReminder = headerParts.Length > 1 ? headerParts.Last() : string.Empty;
                    
                    //get first 3 chars from headerFirstPart
                    var safeApiKey = headerFirstPart.Substring(0, 3) + "---" + headerFirstPart.Substring(headerFirstPart.Length - 3) + "_" + headerReminder;

                    headerValues.Add(safeApiKey);
                }
                
                return headerValues;
            }

            return header.Value;
        }

        private static JToken GetObfuscatedContent(JToken jToken, string[] sensitiveFields)
        {
            if (jToken == null)
            {
                return new JObject();
            }
            
            switch (jToken)
            {
                case JArray jArray:
                    ObfuscateJArray(sensitiveFields, jArray);
                    break;
                case JObject jObject:
                    ObfuscateJObject(sensitiveFields, jObject);
                    GetObfuscatedContent(jToken["fromAddress"], sensitiveFields);
                    GetObfuscatedContent(jToken["fromUTXO"], sensitiveFields);
                    break;
            }

            return jToken;
        }

        private static void ObfuscateJObject(string[] sensitiveFields, JObject jObject)
        {
            foreach (var field in sensitiveFields)
            {
                RedactJTokenField(jObject, field);
            }
        }

        private static void ObfuscateJArray(string[] sensitiveFields, JArray jArray)
        {
            foreach (var field in sensitiveFields)
            {
                foreach (var item in jArray)
                {
                    RedactJTokenField(item, field);
                }
            }
        }

        private static void RedactJTokenField(JToken jObject, string field)
        {
            if (jObject?[field] != null)
            {
                jObject[field] = Redacted;
            }
        }

        private static string GetObfuscatedRequestUri(HttpRequestMessage request)
        {
            var obfuscatedUri = request.RequestUri?.AbsoluteUri;
            
            foreach (var field in SensitiveFieldList)
            {
                if (obfuscatedUri?.Contains(field) ?? false)
                {
                    var fieldSplit = obfuscatedUri.Split((field + "=").ToCharArray());
                    var valueSplit = fieldSplit[1].Split('&');

                    obfuscatedUri = fieldSplit[0] + field + "=" + Redacted + string.Join("&", valueSplit.Skip(1));
                }
            }

            return obfuscatedUri;
        }

        internal static async Task<StringBuilder> PrepareResponseLog(HttpResponseMessage response, bool hideSecrets)
        {
            var sb = new StringBuilder();

            sb.AppendLine($"<<<<<<<<<<<<<<< Tatum API RESPONSE TestNet <<<<<<<<<<<<<<<<<");

            sb.AppendLine($"Status code: {response.StatusCode}");

            if (response.Headers != null)
            {
                sb.AppendLine($"Headers:");
                foreach (var header in response.Headers)
                {
                    sb.AppendLine($"{header.Key}: {string.Join(",", header.Value)}");
                }
            }

            var mediaType = response.Content.Headers?.ContentType?.MediaType;

            var content = await response.Content.ReadAsStringAsync();
            
            switch (mediaType)
            {
                case "application/octet-stream":
                case null :
                    content = "( binary data )";
                    break;
                case "multipart/form-data":
                    if(content.Contains("application/octet-stream"))
                    {
                        content = "( binary data )";
                    }
                    break;
                case "application/json":
                    if(hideSecrets)
                    {
                        content = GetObfuscatedContent(JToken.Parse(content), SensitiveFieldList).ToString(Formatting.Indented);
                    }
                    content = FormatJson(content);
                    break;
            }

            sb.AppendLine($"Body: {Truncate(content)}");

            sb.AppendLine($"<<<<<<<<<<<<<<< /Tatum API RESPONSE TestNet <<<<<<<<<<<<<<<<<");

            return sb;
        }
        
        internal static StringBuilder PrepareExceptionLog(Exception e)
        {
            var sb = new StringBuilder();

            sb.AppendLine($"<<<<<<<<<<<<<<< Tatum API EXCEPTION <<<<<<<<<<<<<<<<<");

            sb.AppendLine($"Message: {e.Message}");

            sb.AppendLine($"StackTrace: {e.StackTrace}");

            sb.AppendLine($"<<<<<<<<<<<<<<< /Tatum API RESPONSE <<<<<<<<<<<<<<<<<");
            
            return sb;
        }
        
        private static void ReplaceDebugUserAgent(HttpRequestMessage request)
        {
            if (request.Headers.TryGetValues("User-Agent", out var userAgent))
            {
                foreach (var headerValue in userAgent)
                {
                    if (!headerValue.StartsWith("Tatum_SDK_CSharp")) continue;

                    var debugUserAgent = headerValue.Replace("%2F", "_DebugMode%2F");

                    request.Headers.Remove("User-Agent");
                    request.Headers.Add("User-Agent", debugUserAgent);
                    return;
                }
            }
        }

        private static string Truncate(string value)
        {
            if (value == null)
            {
                return value;
            }
            
            return value.Length <= MaxLength ? value : value.Substring(0, MaxLength);
        }
        
        private static string FormatJson(string uglyJson)
        {
            var json = JToken.Parse(uglyJson);
            return json.ToString(Formatting.Indented);
        }
    }
}