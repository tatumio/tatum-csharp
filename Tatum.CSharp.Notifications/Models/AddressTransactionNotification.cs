using Tatum.CSharp.Core.Models;

namespace Tatum.CSharp.Notifications.Models
{
    public class AddressTransactionNotification
    {
        public string Id { get; set; }
        
        public Chain Chain { get; set; }

        public string Address { get; set; }
        
        public string Url { get; set; }
    }
}