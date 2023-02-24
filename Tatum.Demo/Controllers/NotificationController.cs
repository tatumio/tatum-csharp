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
    public async Task<AddressEventNotification> Subscribe(AddressEventNotification addressEventNotification)
    {
        var result = await _tatumSdk.Notifications.Subscribe.AddressEvent(addressEventNotification);

        if (result.Success)
        {
            return result.Value;
        }

        throw new Exception(result.ErrorMessage);
    }
    
    [HttpDelete(Name = "Unsubscribe")]
    public async Task Unsubscribe(string notificationId)
    {
        var result = await _tatumSdk.Notifications.Unsubscribe(notificationId);
        
        if (!result.Success)
        {
            throw new Exception(result.ErrorMessage);
        }
    }
}