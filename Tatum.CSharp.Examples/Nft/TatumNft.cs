using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Tatum.CSharp.Core.Models;
using Tatum.CSharp.Nft.Models;
using Tatum.CSharp.Utils.DebugMode;
using Xunit;

namespace Tatum.CSharp.Examples.Nft;

public class TatumNft
{
    [Fact]
    public async Task Balance_Single()
    {
        var httpClient = new DebugModeHandler();
        httpClient.InnerHandler = new HttpClientHandler();

        var apiKey = Environment.GetEnvironmentVariable("INTEGRATION_TEST_APIKEY");
        
        var tatum = new TatumSdk(new HttpClient(httpClient), apiKey);

        const string address = "0x7968ac1f93e1967492d78701b88004074891e9a1";
        
        var nftBalanceDetails = new NftBalanceDetails
        {
            Chain = Chain.Ethereum,
            Addresses = new string[]
            {
                address
            }
        };

        var balances = await tatum.Nft.Balance(nftBalanceDetails);

        balances.Should().NotBeNull();
        balances.ChainNftBalances.Should().ContainKey(Chain.Ethereum);
        var balance = balances.ChainNftBalances[Chain.Ethereum];
        balance.AddressNftBalances.Should().ContainKey(address);
        var addressBalance = balance.AddressNftBalances[address];
        addressBalance.Should().NotBeEmpty();
        var nftBalance = addressBalance[0];
        
        nftBalance.TokenId.Should().NotBeNullOrEmpty();
        nftBalance.ContractAddress.Should().NotBeNullOrEmpty();
        nftBalance.MetadataUri.Should().NotBeNullOrEmpty();
        nftBalance.Metadata.Should().NotBeNullOrEmpty();
    }
    
    [Fact]
    public async Task Balance_Many()
    {
        var httpClient = new DebugModeHandler();
        httpClient.InnerHandler = new HttpClientHandler();

        var apiKey = Environment.GetEnvironmentVariable("INTEGRATION_TEST_APIKEY");
        
        var tatum = new TatumSdk(new HttpClient(httpClient), apiKey);

        const string address = "0x7968ac1f93e1967492d78701b88004074891e9a1";
        
        var nftBalanceDetails = new NftBalanceDetails
        {
            Chain = Chain.Ethereum,
            Addresses = new[]
            {
                address
            }
        };

        var balances = await tatum.Nft.Balance(new []{nftBalanceDetails});

        balances.Should().NotBeNull();
        balances.ChainNftBalances.Should().ContainKey(Chain.Ethereum);
        var balance = balances.ChainNftBalances[Chain.Ethereum];
        balance.AddressNftBalances.Should().ContainKey(address);
        var addressBalance = balance.AddressNftBalances[address];
        addressBalance.Should().NotBeEmpty();
        var nftBalance = addressBalance[0];
        
        nftBalance.TokenId.Should().NotBeNullOrEmpty();
        nftBalance.ContractAddress.Should().NotBeNullOrEmpty();
        nftBalance.MetadataUri.Should().NotBeNullOrEmpty();
        nftBalance.Metadata.Should().NotBeNullOrEmpty();
    }
    
    [Fact]
    public async Task GetNftMetadata_Single()
    {
        var httpClient = new DebugModeHandler();
        httpClient.InnerHandler = new HttpClientHandler();

        var apiKey = Environment.GetEnvironmentVariable("INTEGRATION_TEST_APIKEY");
        
        var tatum = new TatumSdk(new HttpClient(httpClient), apiKey);

        var getNftMetadataDetails = new GetNftMetadataDetails
        {
            Chain = Chain.Ethereum,
            ContractAddress = "0x211500d1960bdb7ba3390347ffd8ad486b897a18",
            TokenId = "23100000000000"
        };

        var nftMetadata = await tatum.Nft.GetNftMetadata(getNftMetadataDetails);
        
        nftMetadata.Should().NotBeNull();
        nftMetadata.ChainNftMetadata.Should().ContainKey(Chain.Ethereum);
        var metadata = nftMetadata.ChainNftMetadata[Chain.Ethereum];
        metadata.Should().NotBeEmpty();
        var nftMetadataDetails = metadata[0];
        nftMetadataDetails.Data.Should().NotBeNullOrEmpty();
        nftMetadataDetails.ContractAddress.Should().NotBeNullOrEmpty();
        nftMetadataDetails.TokenId.Should().NotBeNullOrEmpty();
    }
    
    [Fact]
    public async Task GetNftMetadata_Many()
    {
        var httpClient = new DebugModeHandler();
        httpClient.InnerHandler = new HttpClientHandler();

        var apiKey = Environment.GetEnvironmentVariable("INTEGRATION_TEST_APIKEY");
        
        var tatum = new TatumSdk(new HttpClient(httpClient), apiKey);

        var getNftMetadataDetails = new GetNftMetadataDetails
        {
            Chain = Chain.Ethereum,
            ContractAddress = "0xf04bc01d562ad9f750db0235a4ac396551a7f846",
            TokenId = "10"
        };

        var nftMetadata = await tatum.Nft.GetNftMetadata(new []{getNftMetadataDetails});
        
        nftMetadata.Should().NotBeNull();
        nftMetadata.ChainNftMetadata.Should().ContainKey(Chain.Ethereum);
        var metadata = nftMetadata.ChainNftMetadata[Chain.Ethereum];
        metadata.Should().NotBeEmpty();
        var nftMetadataDetails = metadata[0];
        nftMetadataDetails.Data.Should().NotBeNullOrEmpty();
        nftMetadataDetails.ContractAddress.Should().NotBeNullOrEmpty();
        nftMetadataDetails.TokenId.Should().NotBeNullOrEmpty();
    }
    
    [Fact]
    public async Task GetAllNftTransactions()
    {
        var httpClient = new DebugModeHandler();
        httpClient.InnerHandler = new HttpClientHandler();

        var apiKey = Environment.GetEnvironmentVariable("INTEGRATION_TEST_APIKEY");
        
        var tatum = new TatumSdk(new HttpClient(httpClient), apiKey);

        var getAllNftTransactionsQuery = new GetAllNftTransactionsQuery
        {
            GetAllNftTransactionsDetails = new List<GetAllNftTransactionDetails>()
            {
                new()
                {
                    Chain = Chain.Ethereum,
                    TokenId = "10",
                    ContractAddress = "0xf04bc01d562ad9f750db0235a4ac396551a7f846"
                }
            }
        };

        var transactions = await tatum.Nft.GetAllNftTransactions(getAllNftTransactionsQuery);
        
        transactions.Should().NotBeNull();
        transactions.ChainNftTransactions.Should().ContainKey(Chain.Ethereum);
        var chainTransactions = transactions.ChainNftTransactions[Chain.Ethereum];
        chainTransactions.Should().NotBeEmpty();
        var transaction = chainTransactions[0];
        transaction.ContractAddress.Should().NotBeNullOrEmpty();
        transaction.TokenId.Should().NotBeNullOrEmpty();
        transaction.TxId.Should().NotBeNullOrEmpty();
        transaction.BlockNumber.Should().BePositive();
        
    }
    
    [Fact]
    public async Task Collection_GetAllNfts()
    {
        var httpClient = new DebugModeHandler();
        httpClient.InnerHandler = new HttpClientHandler();

        var apiKey = Environment.GetEnvironmentVariable("INTEGRATION_TEST_APIKEY");
        
        var tatum = new TatumSdk(new HttpClient(httpClient), apiKey);

        const string contractAddress = "0x211500d1960bdb7ba3390347ffd8ad486b897a18";
        
        var getAllNftsQuery = new GetAllNftsQuery()
        {
            NftDetails = new List<NftDetails>()
            {
                new()
                {
                    Chain = Chain.Ethereum,
                    ContractAddress = contractAddress
                }
            }
        };
        
        var nftsInCollections = await tatum.Nft.Collection.GetAllNfts(getAllNftsQuery);

        nftsInCollections.Should().NotBeNull();
        nftsInCollections.ChainNftsInCollection.Should().ContainKey(Chain.Ethereum);
        var chainNfts = nftsInCollections.ChainNftsInCollection[Chain.Ethereum];
        chainNfts.ContractAddressNftsInCollection.Should().ContainKey(contractAddress);
        var nfts = chainNfts.ContractAddressNftsInCollection[contractAddress];
        nfts.Should().NotBeEmpty();
        var nft = nfts[0];
        nft.TokenId.Should().NotBeNullOrEmpty();
        nft.Url.Should().NotBeNullOrEmpty();
        nft.Metadata.Should().NotBeNullOrEmpty();
    }
}