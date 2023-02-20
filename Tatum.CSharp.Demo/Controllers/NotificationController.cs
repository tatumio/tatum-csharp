using Microsoft.AspNetCore.Mvc;
using Tatum.CSharp.Notifications.Models;

namespace Tatum.CSharp.Demo.Controllers;

[ApiController]
[Route("[controller]")]
public class NotificationController : ControllerBase
{
    private readonly ITatumSdk _tatumSdk;

    public NotificationController(ITatumSdk tatumSdk)
    {
        _tatumSdk = tatumSdk;
    }

    [HttpGet(Name = "GetCurrent")]
    public async Task<List<INotification>> GetAll()
    {
        var result = await _tatumSdk.Notifications.GetAll();

        if (result.Success)
        {
            return result.Value;
        }

        throw new Exception(result.ErrorMessage);
    }
}