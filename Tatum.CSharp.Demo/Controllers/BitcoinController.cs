using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tatum.CSharp.Core.Model;
using Tatum.CSharp.Demo.ExampleServices.Bitcoin;

namespace Tatum.CSharp.Demo.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class BitcoinController : ControllerBase
{
    private readonly GenerateWalletExampleService _generateWalletExampleService;
    private readonly GeneratePrivateKeyExampleService _generatePrivateKeyExampleService;
    private readonly GenerateAddressExampleService _generateAddressExampleService;
    private readonly GetBalanceExampleService _getBalanceExampleService;
    private readonly GetTransactionsExampleService _getTransactionsExampleService;
    private readonly BlockchainTransferExampleService _blockchainTransferExampleService;

    public BitcoinController(
        GenerateWalletExampleService generateWalletExampleService,
        GeneratePrivateKeyExampleService generatePrivateKeyExampleService,
        GenerateAddressExampleService generateAddressExampleService,
        GetBalanceExampleService getBalanceExampleService,
        GetTransactionsExampleService getTransactionsExampleService,
        BlockchainTransferExampleService blockchainTransferExampleService)
    {
        _generateWalletExampleService = generateWalletExampleService;
        _generatePrivateKeyExampleService = generatePrivateKeyExampleService;
        _generateAddressExampleService = generateAddressExampleService;
        _getBalanceExampleService = getBalanceExampleService;
        _getTransactionsExampleService = getTransactionsExampleService;
        _blockchainTransferExampleService = blockchainTransferExampleService;
    }

    [HttpGet]
    public Wallet GenerateWallet() => 
        _generateWalletExampleService.GenerateWallet();

    [HttpPost]
    public PrivKey GeneratePrivateKey([FromBody] PrivKeyRequest request) =>
        _generatePrivateKeyExampleService.GeneratePrivateKey(request);


    [HttpGet]
    public async Task<GeneratedAddressBtc> GenerateAddress(string xpub, int index) =>
        await _generateAddressExampleService.GenerateAddress(xpub, index);

    [HttpGet]
    public async Task<BtcBasedBalance> GetBalance(string address) =>
        await _getBalanceExampleService.GetBalance(address);

    [HttpGet]
    public async Task<List<BtcTx>> GetTransactions(string address) =>
        await _getTransactionsExampleService.GetTransactions(address);

    [HttpPost]
    public async Task<TransactionHash> BlockchainTransfer(string fromAddress, string toAddress, string amount) =>
        await _blockchainTransferExampleService.BlockchainTransfer(fromAddress, toAddress, amount);

}