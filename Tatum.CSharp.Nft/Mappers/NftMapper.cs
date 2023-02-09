using System.Collections.Generic;
using Tatum.CSharp.Nft.Models;
using Tatum.CSharp.Nft.Models.Responses;

namespace Tatum.CSharp.Nft.Mappers
{
    public static class NftMapper
    {
        public static List<AddressNftBalance> Map(NftBalanceResponse nftBalanceResponse)
        {
            var result = new List<AddressNftBalance>();

            foreach (var tokenMetadataDetail in nftBalanceResponse.TokenMetadataDetails)
            {
                result.Add(new AddressNftBalance
                {
                    ContractAddress = nftBalanceResponse.ContractAddress,
                    TokenId = tokenMetadataDetail.TokenId,
                    MetadataUri = tokenMetadataDetail.Url,
                    Metadata = tokenMetadataDetail.Metadata
                });
            }

            return result;
        }
        
        public static ContractAddressNftsInCollection Map(NftInCollectionResponse nftInCollectionResponse)
        {
            return new ContractAddressNftsInCollection
            {
                TokenId = nftInCollectionResponse.TokenId,
                Url = nftInCollectionResponse.TokenMetadataDetails.Url,
                Metadata = nftInCollectionResponse.TokenMetadataDetails.Metadata
            };
        }
        
        public static ChainNftTransaction Map(NftTransactionResponse nftTransactionResponse)
        {
            return new ChainNftTransaction
            {
                BlockNumber = nftTransactionResponse.BlockNumber,
                TxId = nftTransactionResponse.TransactionId,
                ContractAddress = nftTransactionResponse.ContractAddress,
                TokenId = nftTransactionResponse.TokenId,
                From = nftTransactionResponse.FromAddress,
                To = nftTransactionResponse.ToAddress
            };
        }
        
        public static ChainNftMetadata Map(string contractAddress, string tokenId, NftMetadataResponse nftMetadataResponse)
        {
            return new ChainNftMetadata
            {
                ContractAddress = contractAddress,
                TokenId = tokenId,
                Data = nftMetadataResponse.Data
            };
        }
    }
}