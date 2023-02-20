using System.Text.Json;
using Tatum.CSharp;
using Tatum.CSharp.Core.Models;
using Tatum.CSharp.Notifications.Models.Notifications;

var tatumSdk = await TatumSdk.InitAsync(Network.Testnet, "<YOUR_API_KEY>");

var subscriptionResult = await tatumSdk
    .Notifications
    .Subscribe
    .AddressTransaction(new AddressTransactionNotification
{
    Chain = AddressTransactionChain.Ethereum,
    Address = "invalid-address",
    Url = "https://<YOUR_WEBHOOK_URL>"
});

if (subscriptionResult.Success) {
    // Process subscription result
    var valueString = JsonSerializer.Serialize(subscriptionResult.Value);
    Console.WriteLine(valueString);
} 
else
{
    // Print error
    Console.WriteLine(subscriptionResult.ErrorMessage);
}