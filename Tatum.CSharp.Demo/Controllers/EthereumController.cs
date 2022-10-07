using Microsoft.AspNetCore.Mvc;
using Tatum.CSharp.Core.Model;
using Tatum.CSharp.Ethereum.Clients;

namespace Tatum.CSharp.Demo.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class EthereumController : ControllerBase
{
    private readonly ILogger<EthereumController> _logger;
    private readonly IEthereumClient _ethereumClient;

    public EthereumController(ILogger<EthereumController> logger, IEthereumClient ethereumClient)
    {
        _logger = logger;
        _ethereumClient = ethereumClient;
    }

    [HttpGet(Name = "GenerateWallet")]
    public async Task<Wallet> GenerateWallet()
    {
        
        return await _ethereumClient.EthereumBlockchain.EthGenerateWalletAsync();
    }
}