using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

/// <summary>
/// Summary description for IFungibleTokenClient
/// </summary>
/// 
namespace Tatum
{
    public interface IFungibleTokenClient
    {
        Task<FungibleToken> ChainDeployErc20(string chain, string symbol, string name, string totalcap,string supply,int digits,string address,string privatekey,string gaslimit,string gasprice);
        Task<FungibleToken> ChainDeployErc20KMS(string chain, string symbol, string name, string totalcap, string supply, int digits, string address, string signatureid, string gaslimit, string gasprice);
        Task<FungibleToken> ChainDeployCeloErc20(string chain, string symbol, string name, string totalcap, string supply, int digits, string address, string fromprivatekey, string feecurrency);
        Task<FungibleToken> ChainDeployCeloErc20KMS(string chain, string symbol, string name, string totalcap, string supply, int digits, string address, string signatureid, string feecurrency);



        Task<FungibleToken> ChainMintErc20(string chain, string amount, string to, string contractaddress, string fromprivatekey);
        Task<FungibleToken> ChainMintErc20KMS(string chain, string amount, string to, string contractaddress, string signatureid);
        Task<FungibleToken> ChainMintErc20(string chain, string amount, string to, string contractaddress, string fromprivatekey,string feecurrency);
        Task<FungibleToken> ChainMintCeloErc20KMS(string chain, string amount, string to, string contractaddress, string signatureid,string feecurrency);


        Task<FungibleToken> ChainBurnErc20(string chain, string amount, string contractaddress, string fromprivatekey);
        Task<FungibleToken> ChainBurnErc20KMS(string chain, string amount, string contractaddress, string signatureid);
        Task<FungibleToken> ChainBurnCeloErc20(string chain, string amount, string contractaddress, string fromprivatekey,string feecurrency);
        Task<FungibleToken> ChainBurnCeloErc20KMS(string chain, string amount, string contractaddress, string signatureid,string feecurrency);



        Task<FungibleToken> ApproveErc20(string chain, string amount,string spender, string contractaddress, string fromprivatekey);
        Task<FungibleToken> ApproveErc20KMS(string chain, string amount, string spender, string contractaddress, string signatureid);
        Task<FungibleToken> ApproveCeloErc20(string chain, string amount, string spender, string contractaddress, string fromprivatekey,string feecurrency);
        Task<FungibleToken> ApproveCeloErc20KMS(string chain, string amount, string spender, string contractaddress, string signatureid,string feecurrency);


        Task<FungibleToken> ChainTransferEthErc20(string chain,string currency,string to, string amount,string contractaddress,string digits, string fromprivatekey, string gaslimit, string gasprice);
        Task<FungibleToken> ChainTransferEthErc20KMS(string chain, string currency, string to, string amount, string contractaddress, string digits, string signatureid, string gaslimit, string gasprice);
        Task<FungibleToken> ChainTransferBscBep20(string chain,  string to, string amount, string contractaddress, string digits, string fromprivatekey, string gaslimit, string gasprice);
        Task<FungibleToken> ChainTransferBscBep20KMS(string chain, string currency, string to, string amount, string contractaddress, string digits, string signatureid, string gaslimit, string gasprice);
        Task<FungibleToken> ChainTransferCeloErc20Token(string chain,  string to, string amount, string contractaddress, string digits, string fromprivatekey, string feecurrency);
        Task<FungibleToken> ChainTransferCeloErc20TokenKMS(string chain, string to, string amount, string contractaddress, string digits, string signatureid, string feecurrency);



        Task<FungibleToken> GetErc20AccountBalance(string chain, string address, string contractaddress);




    }
}