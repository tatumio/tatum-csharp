using System.Text.Json;
using Tatum.CSharp;
using Tatum.CSharp.Core;
using Tatum.CSharp.Core.Models;
using Tatum.CSharp.Notifications.Models.Responses;

// Initialize Tatum SDK
TatumSdk tatumSdk = await TatumSdk.InitAsync(Network.Testnet, "798811c7-5e96-471a-8244-98f750dd8512_100");

Result<List<WebhookExecutionResponse>> executedWebhooks = await tatumSdk.Notifications.GetAllExecutedWebhooks();

Console.WriteLine(JsonSerializer.Serialize(executedWebhooks.Value, new JsonSerializerOptions() { WriteIndented = true}));