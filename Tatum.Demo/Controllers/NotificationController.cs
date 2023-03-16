using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Tatum.Core;
using Tatum.Notifications.Models;
using Tatum.Notifications.Models.Notifications;
using Tatum.Notifications.Models.Notifications.SupportedChains;
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
    /// Endpoint used to subscribe to a new AddressEvent webhook notification.
    /// </summary>
    /// <param name="chain">Blockchain of choice.</param>
    /// <param name="address">Blockchain address on which events will trigger notification.</param>
    /// <param name="url">Url that should be called on event trigger.</param>
    [HttpPost(Name = "SubscribeAddressEvent")]
    public async Task<ActionResult<AddressBasedNotification<AddressEventChain>>> SubscribeAddressEvent([Required] AddressEventChain chain, [Required] string address, [Required] string url) 
        => await SubscribeAddress(chain, address, url, _tatumSdk.Notifications.Subscribe.AddressEvent);
    
    /// <summary>
    /// Endpoint used to subscribe to a new FailedTxPerBlock webhook notification.
    /// </summary>
    /// <param name="chain">Blockchain of choice.</param>
    /// <param name="url">Url that should be called on event trigger.</param>
    [HttpPost(Name = "SubscribeFailedTxPerBlock")]
    public async Task<ActionResult<BlockBasedNotification<FailedTxPerBlockChain>>> SubscribeFailedTxPerBlock([Required] FailedTxPerBlockChain chain, string? url) 
        => await SubscribeBlock(chain, url, _tatumSdk.Notifications.Subscribe.FailedTxPerBlock);
    
    /// <summary>
    /// Endpoint used to subscribe to a new IncomingNativeTx webhook notification.
    /// </summary>
    /// <param name="chain">Blockchain of choice.</param>
    /// <param name="address">Blockchain address on which events will trigger notification.</param>
    /// <param name="url">Url that should be called on event trigger.</param>
    [HttpPost(Name = "SubscribeIncomingNativeTx")]
    public async Task<ActionResult<AddressBasedNotification<IncomingNativeTxChain>>> SubscribeIncomingNativeTx([Required] IncomingNativeTxChain chain,[Required]  string address,[Required]  string url) 
        => await SubscribeAddress(chain, address, url, _tatumSdk.Notifications.Subscribe.IncomingNativeTx);
    
    /// <summary>
    /// Endpoint used to subscribe to a new OutgoingNativeTx webhook notification.
    /// </summary>
    /// <param name="chain">Blockchain of choice.</param>
    /// <param name="address">Blockchain address on which events will trigger notification.</param>
    /// <param name="url">Url that should be called on event trigger.</param>
    [HttpPost(Name = "SubscribeOutgoingNativeTx")]
    public async Task<ActionResult<AddressBasedNotification<OutgoingNativeTxChain>>> SubscribeOutgoingNativeTx([Required] OutgoingNativeTxChain chain,[Required]  string address,[Required]  string url) 
        => await SubscribeAddress(chain, address, url, _tatumSdk.Notifications.Subscribe.OutgoingNativeTx);
    
    /// <summary>
    /// Endpoint used to subscribe to a new OutgoingFailedTx webhook notification.
    /// </summary>
    /// <param name="chain">Blockchain of choice.</param>
    /// <param name="address">Blockchain address on which events will trigger notification.</param>
    /// <param name="url">Url that should be called on event trigger.</param>
    [HttpPost(Name = "SubscribeOutgoingFailedTx")]
    public async Task<ActionResult<AddressBasedNotification<OutgoingFailedTxChain>>> SubscribeOutgoingFailedTx([Required] OutgoingFailedTxChain chain,[Required]  string address,[Required]  string url) 
        => await SubscribeAddress(chain, address, url, _tatumSdk.Notifications.Subscribe.OutgoingFailedTx);
    
    /// <summary>
    /// Endpoint used to subscribe to a new PaidFee webhook notification.
    /// </summary>
    /// <param name="chain">Blockchain of choice.</param>
    /// <param name="address">Blockchain address on which events will trigger notification.</param>
    /// <param name="url">Url that should be called on event trigger.</param>
    [HttpPost(Name = "SubscribePaidFee")]
    public async Task<ActionResult<AddressBasedNotification<PaidFeeChain>>> SubscribePaidFee([Required] PaidFeeChain chain,[Required]  string address,[Required]  string url) 
        => await SubscribeAddress(chain, address, url, _tatumSdk.Notifications.Subscribe.PaidFee);
    
    /// <summary>
    /// Endpoint used to subscribe to a new IncomingInternalTx webhook notification.
    /// </summary>
    /// <param name="chain">Blockchain of choice.</param>
    /// <param name="address">Blockchain address on which events will trigger notification.</param>
    /// <param name="url">Url that should be called on event trigger.</param>
    [HttpPost(Name = "SubscribeIncomingInternalTx")]
    public async Task<ActionResult<AddressBasedNotification<IncomingInternalTxChain>>> SubscribeIncomingInternalTx([Required] IncomingInternalTxChain chain,[Required]  string address,[Required]  string url) 
        => await SubscribeAddress(chain, address, url, _tatumSdk.Notifications.Subscribe.IncomingInternalTx);
    
    /// <summary>
    /// Endpoint used to subscribe to a new OutgoingInternalTx webhook notification.
    /// </summary>
    /// <param name="chain">Blockchain of choice.</param>
    /// <param name="address">Blockchain address on which events will trigger notification.</param>
    /// <param name="url">Url that should be called on event trigger.</param>
    [HttpPost(Name = "SubscribeOutgoingInternalTx")]
    public async Task<ActionResult<AddressBasedNotification<OutgoingInternalTxChain>>> SubscribeOutgoingInternalTx([Required] OutgoingInternalTxChain chain,[Required]  string address,[Required]  string url) 
        => await SubscribeAddress(chain, address, url, _tatumSdk.Notifications.Subscribe.OutgoingInternalTx);
    
    /// <summary>
    /// Endpoint used to subscribe to a new IncomingFungibleTx webhook notification.
    /// </summary>
    /// <param name="chain">Blockchain of choice.</param>
    /// <param name="address">Blockchain address on which events will trigger notification.</param>
    /// <param name="url">Url that should be called on event trigger.</param>
    [HttpPost(Name = "SubscribeIncomingFungibleTx")]
    public async Task<ActionResult<AddressBasedNotification<IncomingFungibleTxChain>>> SubscribeIncomingFungibleTx([Required] IncomingFungibleTxChain chain,[Required]  string address,[Required]  string url) 
        => await SubscribeAddress(chain, address, url, _tatumSdk.Notifications.Subscribe.IncomingFungibleTx);
    
    /// <summary>
    /// Endpoint used to subscribe to a new OutgoingFungibleTx webhook notification.
    /// </summary>
    /// <param name="chain">Blockchain of choice.</param>
    /// <param name="address">Blockchain address on which events will trigger notification.</param>
    /// <param name="url">Url that should be called on event trigger.</param>
    [HttpPost(Name = "SubscribeOutgoingFungibleTx")]
    public async Task<ActionResult<AddressBasedNotification<OutgoingFungibleTxChain>>> SubscribeOutgoingFungibleTx([Required] OutgoingFungibleTxChain chain,[Required]  string address,[Required]  string url) 
        => await SubscribeAddress(chain, address, url, _tatumSdk.Notifications.Subscribe.OutgoingFungibleTx);
    
    /// <summary>
    /// Endpoint used to subscribe to a new IncomingNftTx webhook notification.
    /// </summary>
    /// <param name="chain">Blockchain of choice.</param>
    /// <param name="address">Blockchain address on which events will trigger notification.</param>
    /// <param name="url">Url that should be called on event trigger.</param>
    [HttpPost(Name = "SubscribeIncomingNftTx")]
    public async Task<ActionResult<AddressBasedNotification<IncomingNftTxChain>>> SubscribeIncomingNftTx([Required] IncomingNftTxChain chain,[Required]  string address,[Required]  string url) 
        => await SubscribeAddress(chain, address, url, _tatumSdk.Notifications.Subscribe.IncomingNftTx);
    
    /// <summary>
    /// Endpoint used to subscribe to a new OutgoingNftTx webhook notification.
    /// </summary>
    /// <param name="chain">Blockchain of choice.</param>
    /// <param name="address">Blockchain address on which events will trigger notification.</param>
    /// <param name="url">Url that should be called on event trigger.</param>
    [HttpPost(Name = "SubscribeOutgoingNftTx")]
    public async Task<ActionResult<AddressBasedNotification<OutgoingNftTxChain>>> SubscribeOutgoingNftTx([Required] OutgoingNftTxChain chain,[Required]  string address,[Required]  string url) 
        => await SubscribeAddress(chain, address, url, _tatumSdk.Notifications.Subscribe.OutgoingNftTx);
    
    /// <summary>
    /// Endpoint used to subscribe to a new IncomingMultitokenTx webhook notification.
    /// </summary>
    /// <param name="chain">Blockchain of choice.</param>
    /// <param name="address">Blockchain address on which events will trigger notification.</param>
    /// <param name="url">Url that should be called on event trigger.</param>
    [HttpPost(Name = "SubscribeIncomingMultitokenTx")]
    public async Task<ActionResult<AddressBasedNotification<IncomingMultitokenTxChain>>> SubscribeIncomingMultitokenTx([Required] IncomingMultitokenTxChain chain,[Required]  string address,[Required]  string url) 
        => await SubscribeAddress(chain, address, url, _tatumSdk.Notifications.Subscribe.IncomingMultitokenTx);
    
    /// <summary>
    /// Endpoint used to subscribe to a new OutgoingMultitokenTx webhook notification.
    /// </summary>
    /// <param name="chain">Blockchain of choice.</param>
    /// <param name="address">Blockchain address on which events will trigger notification.</param>
    /// <param name="url">Url that should be called on event trigger.</param>
    [HttpPost(Name = "SubscribeOutgoingMultitokenTx")]
    public async Task<ActionResult<AddressBasedNotification<OutgoingMultitokenTxChain>>> SubscribeOutgoingMultitokenTx([Required] OutgoingMultitokenTxChain chain,[Required]  string address,[Required]  string url) 
        => await SubscribeAddress(chain, address, url, _tatumSdk.Notifications.Subscribe.OutgoingMultitokenTx);

    private async Task<ActionResult<AddressBasedNotification<T>>> SubscribeAddress<T>(T chain, string? address, string? url, Func<AddressBasedNotification<T>, Task<Result<AddressBasedNotification<T>>>> subscribeFunc)
    {
        var result = await subscribeFunc(new AddressBasedNotification<T>
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
    
    private async Task<ActionResult<BlockBasedNotification<T>>> SubscribeBlock<T>(T chain, string? url, Func<BlockBasedNotification<T>, Task<Result<BlockBasedNotification<T>>>> subscribeFunc)
    {
        var result = await subscribeFunc(new BlockBasedNotification<T>
        {
            Chain = chain,
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