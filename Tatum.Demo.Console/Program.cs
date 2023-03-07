using System.Text.Json;
using Tatum;
using Tatum.Core;
using Tatum.Core.Models;
using Tatum.Notifications.Models.Responses;

// Initialize Tatum SDK
TatumSdk tatumSdk = await TatumSdk.InitAsync(Network.Testnet, "798811c7-5e96-471a-8244-98f750dd8512_100");

Result<List<WebhookExecutionResponse>> executedWebhooks = await tatumSdk.Notifications.GetAllExecutedWebhooks();

Console.WriteLine(JsonSerializer.Serialize(executedWebhooks.Value, new JsonSerializerOptions() { WriteIndented = true}));