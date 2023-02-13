using Microsoft.AspNetCore.Mvc;
using Tatum.CSharp.Core.Models;
using Tatum.CSharp.Fees.Models;

namespace Tatum.CSharp.Demo.Controllers;

[ApiController]
[Route("[controller]")]
public class FeeController : ControllerBase
{
    private readonly ITatumSdk _tatumSdk;

    public FeeController(ITatumSdk tatumSdk)
    {
        _tatumSdk = tatumSdk;
    }

    [HttpGet(Name = "GetCurrent")]
    public async Task<ChainCurrentFee> GetCurrent()
    {
        return await _tatumSdk.Fees.GetCurrent(Chain.Ethereum);
    }
}