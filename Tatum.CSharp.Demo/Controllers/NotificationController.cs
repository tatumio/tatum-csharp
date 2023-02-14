using Microsoft.AspNetCore.Mvc;
using Tatum.CSharp.Core.Models;

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
    public async Task<Notifications.Models.Notifications> GetAll()
    {
        return await _tatumSdk.Notifications.GetAll();
    }
}