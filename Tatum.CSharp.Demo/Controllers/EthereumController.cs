using Microsoft.AspNetCore.Mvc;
using Tatum.CSharp.Core.Model;
using Tatum.CSharp.Ethereum.Clients;

namespace Tatum.CSharp.Demo.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class EthereumController : ControllerBase
{
    private readonly IEthereumClient _ethereumClient;

    public EthereumController(IEthereumClient ethereumClient)
    {
        _ethereumClient = ethereumClient;
    }

    [HttpGet(Name = "GenerateWallet")]
    public async Task<Wallet> GenerateWallet()
    {
        Wallet wallet = await _ethereumClient.EthereumBlockchain.EthGenerateWalletAsync();
        
        return wallet;
    }
}