using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

/// <summary>
/// Summary description for IUtilsClient
/// </summary>
namespace Tatum
{
    public interface IUtilsClient
    {
        Task<Utils> EstimateFee(string chain,string type);
        Task<Utils> EstimateFeeFromAddress(string chain, string type,string frommAddress,string toAddress,string value);
        Task<Utils> EstimateFeeFromAddress(string chain, string type, string txhash, int index,string toAddress, string value);


        Task<Utils> GetContractAddressFromTransaction(string chain, string hash);


        Task<Utils> GenerateCustodialWallet(string chain, string fromPrivateKey, bool enableFungibleTokens, bool enableNonFungibleTokens, bool enableSemiFungibleTokens, bool enableBatchTransactions, string gasLimit, string gasPrice);
        Task<Utils> GenerateCustodialWalletKMS(string chain, string signatureId,int index, bool enableFungibleTokens, bool enableNonFungibleTokens, bool enableSemiFungibleTokens, bool enableBatchTransactions, string gasLimit, string gasPrice);
        Task<Utils> GenerateCustodialWalletCelo(string chain,string feeCurrency, string fromPrivateKey, bool enableFungibleTokens, bool enableNonFungibleTokens, bool enableSemiFungibleTokens, bool enableBatchTransactions, string gasLimit, string gasPrice);
        Task<Utils> GenerateCustodialWalletCeloKMS(string chain, string feeCurrency, string signatureId, int index, bool enableFungibleTokens, bool enableNonFungibleTokens, bool enableSemiFungibleTokens, bool enableBatchTransactions, string gasLimit, string gasPrice);
        Task<Utils> GenerateCustodialWalletTron(string chain,int feeLimit, string fromPrivateKey, bool enableFungibleTokens, bool enableNonFungibleTokens, bool enableSemiFungibleTokens, bool enableBatchTransactions);
        Task<Utils> GenerateCustodialWalletTronKMS(string chain, int feeLimit, string from, string signatureId, int index, bool enableFungibleTokens, bool enableNonFungibleTokens, bool enableSemiFungibleTokens, bool enableBatchTransactions);



        Task<Utils> TransferCustodialWallet(string chain, string custodialAddress, string tokenAddress, int contractType, string recipient, string amount, string tokenId, string fromPrivateKey, string gasLimit, string gasPrice);
        Task<Utils> TransferCustodialWalletKMS(string chain, string custodialAddress, string tokenAddress, int contractType, string recipient, string amount, string tokenId, string signatureId,int index, string gasLimit, string gasPrice);
        Task<Utils> TransferCustodialWalletCelo(string chain, string custodialAddress, string tokenAddress, int contractType, string recipient, string amount, string tokenId, string fromPrivateKey,string feecurrency, string gasLimit, string gasPrice);
        Task<Utils> TransferCustodialWalletCeloKMS(string chain, string custodialAddress, string tokenAddress, int contractType, string recipient, string amount, string tokenId, string signatureId, int index,string feeCurrency, string gasLimit, string gasPrice);
        Task<Utils> TransferCustodialWalletTron(string chain, string custodialAddress, string tokenAddress, int contractType, string recipient, string amount, string tokenId, string fromPrivateKey, int feeLimit);
        Task<Utils> TransferCustodialWalletTronKMS(string chain, string custodialAddress, string tokenAddress, int contractType, string recipient, string amount, string tokenId, string signatureId, int index, int feeLimit, string from);






        Task<Utils> TransferCustodialWalletBatch(string chain, string custodialAddress, string tokenAddress, int contractType, string recipient, string amount, string tokenId, string fromPrivateKey, string gasLimit, string gasPrice);
        Task<Utils> TransferCustodialWalletBatchKMS(string chain, string custodialAddress, string tokenAddress, int contractType, string recipient, string amount, string tokenId, string signatureId, int index, string gasLimit, string gasPrice);
        Task<Utils> TransferCustodialWalletBatchCelo(string chain, string custodialAddress, string tokenAddress, int contractType, string recipient, string amount, string tokenId, string fromPrivateKey, string feecurrency, string gasLimit, string gasPrice);
        Task<Utils> TransferCustodialWalletBatchCeloKMS(string chain, string custodialAddress, string tokenAddress, int contractType, string recipient, string amount, string tokenId, string signatureId, int index, string feeCurrency, string gasLimit, string gasPrice);
        Task<Utils> TransferCustodialWalletBatchTron(string chain, string custodialAddress, string tokenAddress, int contractType, string recipient, string amount, string tokenId, string fromPrivateKey, int feeLimit);
        Task<Utils> TransferCustodialWalletBatchTronKMS(string chain, string custodialAddress, string tokenAddress, int contractType, string recipient, string amount, string tokenId, string signatureId, int index, int feeLimit, string from);




    }
}