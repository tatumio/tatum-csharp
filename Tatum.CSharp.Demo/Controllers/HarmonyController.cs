using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tatum.CSharp.Demo.ExampleServices.Harmony;
using Tatum.CSharp.Evm.Local.Models;
using Tatum.CSharp.Harmony.Core.Model;

namespace Tatum.CSharp.Demo.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class HarmonyController : ControllerBase
{
    private readonly BlockchainTransferExampleService _blockchainTransferExampleService;
    private readonly GenerateAddressExampleService _generateAddressExampleService;
    private readonly GeneratePrivateKeyExampleService _generatePrivateKeyExampleService;
    private readonly GenerateWalletExampleService _generateWalletExampleService;
    private readonly GetBalanceExampleService _getBalanceExampleService;
    private readonly GetTransactionExampleService _getTransactionExampleService;

    public HarmonyController(
        BlockchainTransferExampleService blockchainTransferExampleService,
        GenerateAddressExampleService generateAddressExampleService,
        GeneratePrivateKeyExampleService generatePrivateKeyExampleService,
        GenerateWalletExampleService generateWalletExampleService,
        GetBalanceExampleService getBalanceExampleService,
        GetTransactionExampleService getTransactionExampleService)
    {
        _blockchainTransferExampleService = blockchainTransferExampleService;
        _generateAddressExampleService = generateAddressExampleService;
        _generatePrivateKeyExampleService = generatePrivateKeyExampleService;
        _generateWalletExampleService = generateWalletExampleService;
        _getBalanceExampleService = getBalanceExampleService;
        _getTransactionExampleService = getTransactionExampleService;
    }

    [HttpGet]
    public WalletLocal GenerateWallet() =>
        _generateWalletExampleService.GenerateWallet();

    [HttpPost]
    public PrivKeyLocal GeneratePrivateKey([FromBody] PrivKeyRequestLocal request) =>
        _generatePrivateKeyExampleService.GeneratePrivateKey(request);

    [HttpGet]
    public GeneratedAddressEthLocal GenerateAddress(string xpub, int index) => 
        _generateAddressExampleService.GenerateAddress(xpub, index);

    [HttpGet]
    public async Task<OneBalance> GetBalance(string address) =>
        await _getBalanceExampleService.GetBalance(address);

    [HttpGet]
    public async Task<OneTx> GetTransaction(string hash) =>
        await _getTransactionExampleService.GetTransaction(hash);

    [HttpPost]
    public async Task<TransactionHash> BlockchainTransfer(string fromAddress, string toAddress, string amount) =>
        await _blockchainTransferExampleService.BlockchainTransfer(fromAddress, toAddress, amount);

}
