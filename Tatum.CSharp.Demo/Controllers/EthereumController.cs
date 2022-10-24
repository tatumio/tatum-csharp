using System.Collections.Generic;
using System.Threading.Tasks;
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
    public Wallet GenerateWallet()
    {
        Wallet wallet = _ethereumClient.Local.GenerateWallet();
        
        return wallet;
    }
    
    [HttpPost(Name = "GeneratePrivateKey")]
    public PrivKey GeneratePrivateKey([FromBody] PrivKeyRequest request)
    {
        //request.Mnemonic = "mnemonic from your wallet"
        //request.Index = index of the private key you would like to generate
        
        PrivKey privateKey = _ethereumClient.Local.GenerateAddressPrivateKey(request);
        
        return privateKey;
    }
    
    [HttpGet(Name = "GenerateAddress")]
    public async Task<GeneratedAddressEth> GenerateAddress(string xpub, int index)
    {
        //xpub = "xpub from your wallet"
        //index = index of the address you would like to generate
        
        GeneratedAddressEth address = await _ethereumClient.EthereumBlockchain.EthGenerateAddressAsync(xpub, index);
     
        return address;
    }
    
    [HttpGet(Name = "GetBalance")]
    public async Task<EthBalance> GetBalance(string address)
    {
        EthBalance balance = await _ethereumClient.EthereumBlockchain.EthGetBalanceAsync(address);
        
        return balance;
    }
    
    [HttpGet(Name = "GetTransaction")]
    public async Task<EthTx> GetTransaction(string hash)
    {
        EthTx transaction = await _ethereumClient.EthereumBlockchain.EthGetTransactionAsync(hash);
        
        return transaction;
    }

    private Dictionary<string, string> _someInternalPersistence = new Dictionary<string, string>()
    {
        { "address1", "privateKey1" },
        { "address2", "privateKey2" },
        { "address3", "privateKey3" }
    };

    [HttpPost(Name = "BlockchainTransfer")]
    public async Task<TransactionHash> BlockchainTransfer(string fromAddress, string toAddress, string amount)
    {
        // Need to know the private key of the address that is sending the amount.
        // In this example, we are using a dictionary to store the private keys.
        // In a real world scenario, you would store the private keys in a secure location.
        var fromPrivKey = _someInternalPersistence[fromAddress];

        var transfer = new TransferEthBlockchain(
            null,
            0,
            toAddress, // address you would like to send to
            TransferEthBlockchain.CurrencyEnum.ETH,
            null,
            amount, // amount you would like to send eg. "0.00001"
            fromPrivKey);


        TransactionHash transactionHash = await _ethereumClient.EthereumBlockchain.EthBlockchainTransferAsync(transfer);
        
        return transactionHash;
    }
}
