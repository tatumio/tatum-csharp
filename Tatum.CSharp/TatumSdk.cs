using System;
using System.Net.Http;
using Tatum.CSharp.Fees;
using Tatum.CSharp.Nft;
using Tatum.CSharp.Notifications;

namespace Tatum.CSharp
{
    public class TatumSdk
    {
        private const string BaseUrl = "https://api.tatum.io";
        
        public ITatumNotifications Notifications { get; }
        public ITatumFees Fees { get; }
        public ITatumNft Nft { get; }
        
        public TatumSdk(string apiKey = null) : this(new HttpClient(), apiKey)
        {
        }
        
        public TatumSdk(HttpClient httpClient, string apiKey = null)
        {
            httpClient.BaseAddress = new Uri(BaseUrl);
            
            if(apiKey != null)
            {
                httpClient.DefaultRequestHeaders.Add("x-api-key", apiKey);
            }
            
            Notifications = new TatumNotifications(httpClient);
            
            Fees = new TatumFees(httpClient);
            
            Nft = new TatumNft(httpClient);
        }
    }
}