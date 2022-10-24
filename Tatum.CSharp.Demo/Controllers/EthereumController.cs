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
    
    [HttpPost(Name = "BlockchainTransfer")]
    public async Task<TransactionHash> BlockchainTransfer([FromBody] TransferEthBlockchain transfer)
    {
        //transfer.FromPrivateKey = "private key from your wallet"
        //transfer.To = "address you would like to send to"
        //transfer.Amount = amount you would like to send
        //transfer.Currency = "ETH"
        /*
         new TransferEthBlockchain(
            null, 
            0, 
            TargetAddress, 
            TransferEthBlockchain.CurrencyEnum.ETH, 
            null, 
            "0.00005", 
            StoragePrivKey));
        */
        
        TransactionHash transactionHash = await _ethereumClient.EthereumBlockchain.EthBlockchainTransferAsync(transfer);
        
        return transactionHash;
    }
}