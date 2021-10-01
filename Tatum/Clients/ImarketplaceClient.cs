using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

/// <summary>
/// Summary description for ImarketplaceClient
/// </summary>
/// 

namespace Tatum
{
    public interface ImarketplaceClient
    {

        Task<Marketplace> GenerateMarketplace(string chain,string feeRecipient,string marketplaceFee,string fromPrivateKey,string gasLimit,string gasPrice);
        Task<Marketplace> GenerateMarketplaceKMS(string chain, string feeRecipient, string marketplaceFee, string signatureId,int index, string gasLimit, string gasPrice);
        Task<Marketplace> GenerateMarketplaceCelo(string chain, string feeRecipient,string feeCurrency, string marketplaceFee, string fromPrivateKey, string gasLimit, string gasPrice);
        Task<Marketplace> GenerateMarketplaceCeloKMS(string chain, string feeRecipient, string feeCurrency, string marketplaceFee, string signatureId, int index, string gasLimit, string gasPrice);



        Task<Marketplace> SellAssetOnMarketplace(string chain, string contractAddress, string nftAddress, string seller, string erc20Address, string listingId,string amount,string tokenId,string price,bool isErc721,string fromPrivateKey, string gasLimit, string gasPrice);
        Task<Marketplace> SellAssetOnMarketplaceKMS(string chain, string contractAddress, string nftAddress, string seller, string erc20Address, string listingId, string amount, string tokenId, string price, bool isErc721, string signatureId,int index, string gasLimit, string gasPrice);
        Task<Marketplace> SellAssetOnMarketplaceCelo(string chain,string feeCurrency, string contractAddress, string nftAddress, string seller, string erc20Address, string listingId, string amount, string tokenId, string price, bool isErc721, string fromPrivateKey, string gasLimit, string gasPrice);
        Task<Marketplace> SellAssetOnMarketplaceCeloKMS(string chain, string feeCurrency, string contractAddress, string nftAddress, string seller, string erc20Address, string listingId, string amount, string tokenId, string price, bool isErc721, string signatureId, int index, string gasLimit, string gasPrice);



        Task<Marketplace> BuyAssetOnMarketplace(string chain, string contractAddress, string erc20Address,  string listingId, string amount, string fromPrivateKey, string gasLimit, string gasPrice);
        Task<Marketplace> BuyAssetOnMarketplaceKMS(string chain, string contractAddress,  string erc20Address, string listingId, string amount, string signatureId, int index, string gasLimit, string gasPrice);
        Task<Marketplace> BuyAssetOnMarketplaceCelo(string chain, string feeCurrency, string contractAddress, string erc20Address, string listingId, string amount, string fromPrivateKey, string gasLimit, string gasPrice);
        Task<Marketplace> BuyAssetOnMarketplaceCeloKMS(string chain, string feeCurrency, string contractAddress, string erc20Address, string listingId, string amount,  string signatureId, int index, string gasLimit, string gasPrice);



        Task<Marketplace> CancelSellAssetOnMarketplace(string chain, string contractAddress, string erc20Address, string listingId, string fromPrivateKey, string gasLimit, string gasPrice);
        Task<Marketplace> CancelSellAssetOnMarketplaceKMS(string chain, string erc20Address, string listingId, string signatureId, int index, string gasLimit, string gasPrice);
        Task<Marketplace> CancelSellAssetOnMarketplaceCelo(string chain, string feeCurrency, string erc20Address, string listingId, string amount, string fromPrivateKey, string gasLimit, string gasPrice);
        Task<Marketplace> CancelSellAssetOnMarketplaceCeloKMS(string chain, string feeCurrency, string erc20Address, string listingId, string signatureId, int index, string gasLimit, string gasPrice);



        Task<Marketplace> ApproveErc20MarketplaceSpending(string chain, string marketplaceAddress, string contractAddress,  string amount, string fromPrivateKey, string gasLimit, string gasPrice);
        Task<Marketplace> ApproveErc20MarketplaceSpendingKMS(string chain, string contractAddress, string marketplaceAddress, string amount, string signatureId, int index, string gasLimit, string gasPrice);
        Task<Marketplace> ApproveErc20MarketplaceSpendingCelo(string chain, string feeCurrency, string contractAddress, string marketplaceAddress, string amount, string fromPrivateKey, string gasLimit, string gasPrice);
        Task<Marketplace> ApproveErc20MarketplaceSpendingCeloKMS(string chain, string feeCurrency, string contractAddress, string marketplaceAddress, string amount, string signatureId, int index, string gasLimit, string gasPrice);


        Task<Marketplace> GetListingFromNftMarketplace(string chain,  string contractAddress, string id);
        Task<Marketplace> GetNftMarketplaceFee(string chain, string contractAddress);
        Task<Marketplace> GetNftMarketplaceRecipient(string chain, string contractAddress);


        Task<Marketplace> UpdateFeeRecipient(string chain, string contractAddress, string feeRecipient, string fromPrivateKey, string gasLimit, string gasPrice);
        Task<Marketplace> UpdateFeeRecipientKMS(string chain, string feeRecipient, string signatureId, int index, string gasLimit, string gasPrice);
        Task<Marketplace> UpdateFeeRecipientCelo(string chain, string feeCurrency, string feeRecipient, string fromPrivateKey, string gasLimit, string gasPrice);
        Task<Marketplace> UpdateFeeRecipientCeloKMS(string chain, string feeCurrency, string feeRecipient, string signatureId, int index, string gasLimit, string gasPrice);


        Task<Marketplace> UpdateFee(string chain, string contractAddress, string marketplaceFee,string fromPrivateKey, string gasLimit, string gasPrice);
        Task<Marketplace> UpdateFeeKMS(string chain,  string marketplacefee,  string signatureId, int index, string gasLimit, string gasPrice);
        Task<Marketplace> UpdateFeeCelo(string chain, string feeCurrency,  string marketplaceFee, string fromPrivateKey, string gasLimit, string gasPrice);
        Task<Marketplace> UpdateFeeCeloKMS(string chain, string feeCurrency, string marketplaceFee, string amount, string signatureId, int index, string gasLimit, string gasPrice);




    }
}