using Microsoft.AspNetCore.Mvc;
using Tatum.Notifications.Models;
using Tatum.Notifications.Models.Notifications;
using Tatum.Notifications.Models.Responses;

namespace Tatum.Demo.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class NotificationController : ControllerBase
{
    private readonly ITatumSdk _tatumSdk;

    public NotificationController(ITatumSdk tatumSdk)
    {
        _tatumSdk = tatumSdk;
    }

    [HttpGet(Name = "GetAll")]
    public async Task<List<INotification>> GetAll()
    {
        var result = await _tatumSdk.Notifications.GetAll();

        if (result.Success)
        {
            return result.Value;
        }

        throw new Exception(result.ErrorMessage);
    }
    
    [HttpGet(Name = "GetAllExecutedWebhooks")]
    public async Task<List<WebhookExecutionResponse>> GetAllExecutedWebhooks()
    {
        var result = await _tatumSdk.Notifications.GetAllExecutedWebhooks();

        if (result.Success)
        {
            return result.Value;
        }

        throw new Exception(result.ErrorMessage);
    }
    
    [HttpPost(Name = "Subscribe")]
    public async Task<AddressTransactionNotification> Subscribe(AddressTransactionNotification addressTransactionNotification)
    {
        var result = await _tatumSdk.Notifications.Subscribe.AddressTransaction(addressTransactionNotification);

        if (result.Success)
        {
            return result.Value;
        }

        throw new Exception(result.ErrorMessage);
    }
    
    [HttpDelete(Name = "Unsubscribe")]
    public async Task Unsubscribe(string notificationId)
    {
        await _tatumSdk.Notifications.Unsubscribe(notificationId);
    }
}