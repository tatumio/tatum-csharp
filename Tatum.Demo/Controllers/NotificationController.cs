using Microsoft.AspNetCore.Mvc;
using Tatum.Notifications.Models;
using Tatum.Notifications.Models.Notifications;
using Tatum.Notifications.Models.Responses;

namespace Tatum.Demo.Controllers;

/// <summary>
/// Demo controller for Tatum SDK Notifications.
/// </summary>
[ApiController]
[Route("[controller]/[action]")]
public class NotificationController : ControllerBase
{
    private readonly ITatumSdk _tatumSdk;

    /// <summary>
    /// Create an instance of the controller.
    /// </summary>
    /// <param name="tatumSdk">TatumSdk instance.</param>
    public NotificationController(ITatumSdk tatumSdk)
    {
        _tatumSdk = tatumSdk;
    }

    /// <summary>
    /// Gets all existing notifications.
    /// </summary>
    /// <param name="pageSize">Number of returned records.</param>
    /// <param name="offset">Offset of returned records.</param>
    /// <param name="address">Filter to get notifications by address,</param>
    [HttpGet(Name = "GetAll")]
    public async Task<ActionResult<List<INotification>>> GetAll(int pageSize = 10, int offset = 0, string? address = null)
    {
        var result = await _tatumSdk.Notifications.GetAll(new GetAllNotificationsQuery
        {
            PageSize = pageSize,
            Offset = offset,
            Address = address
        });

        if (result.Success)
        {
            return Ok(result.Value);
        }

        return BadRequest(result.ErrorMessage);
    }
    
    /// <summary>
    /// Gets list of executed webhooks.
    /// </summary>
    /// <param name="pageSize">Number of returned records.</param>
    /// <param name="offset">Offset of returned records.</param>
    /// <param name="sortingDirection">Direction in which records should be sorted.</param>
    /// <param name="filterFailed">Filter returned results by failed field.</param>
    [HttpGet(Name = "GetAllExecutedWebhooks")]
    public async Task<ActionResult<List<WebhookExecutionResponse>>> GetAllExecutedWebhooks(int pageSize = 10, int offset = 0, SortingDirection sortingDirection = SortingDirection.Default, bool? filterFailed = null)
    {
        var result = await _tatumSdk.Notifications.GetAllExecutedWebhooks(new GetAllExecutedWebhooksQuery
        {
            PageSize = pageSize,
            Offset = offset,
            SortingDirection = sortingDirection,
            FilterFailed = filterFailed
        });

        if (result.Success)
        {
            return Ok(result.Value);
        }

        return BadRequest(result.ErrorMessage);
    }
    /// <summary>
    /// Endpoint used to subscribe to a new webhook notification.
    /// </summary>
    /// <param name="chain">Blockchain of choice.</param>
    /// <param name="address">Blockchain address on which events will trigger notification.</param>
    /// <param name="url">Url that should be called on event trigger.</param>
    [HttpPost(Name = "Subscribe")]
    public async Task<ActionResult<AddressEventNotification>> Subscribe(AddressTransactionChain chain = AddressTransactionChain.Ethereum, string? address = null, string? url = null)
    {
        var result = await _tatumSdk.Notifications.Subscribe.AddressEvent(new AddressEventNotification
        {
            Chain = chain,
            Address = address,
            Url = url
        });

        if (result.Success)
        {
            return Ok(result.Value);
        }

        return BadRequest(result.ErrorMessage);
    }
    
    /// <summary>
    /// Removes existing subscription.
    /// </summary>
    /// <param name="notificationId">Id of subscription to remove.</param>
    [HttpDelete(Name = "Unsubscribe")]
    public async Task<IActionResult> Unsubscribe(string notificationId)
    {
        var result = await _tatumSdk.Notifications.Unsubscribe(notificationId);
        
        if (!result.Success)
        {
            return BadRequest(result.ErrorMessage);
        }

        return NoContent();
    }
}