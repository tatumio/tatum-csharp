using System;
using System.Net.Http;
using Tatum.CSharp.Notifications;

namespace Tatum.CSharp
{
    public class Tatum
    {
        private const string BaseUrl = "https://api.tatum.io";
        
        public ITatumNotifications Notifications { get; set; }
        
        public Tatum(string apiKey = null) : this(new HttpClient(), apiKey)
        {
        }
        
        public Tatum(HttpClient httpClient, string apiKey = null)
        {
            httpClient.BaseAddress = new Uri(BaseUrl);
            
            if(apiKey != null)
            {
                httpClient.DefaultRequestHeaders.Add("x-api-key", apiKey);
            }
            
            Notifications = new TatumNotifications(httpClient);
        }
    }
}