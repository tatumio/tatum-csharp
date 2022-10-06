using Nethereum.RPC.Eth.DTOs;
using Nethereum.Web3.Accounts;
using Tatum.CSharp.Core.Model;

namespace Tatum.CSharp.Ethereum.LocalServices
{
    public interface IEthereumLocalService
    {
        Wallet EthGenerateWallet();

        Wallet EthGenerateWallet(string mnemonic);

        GeneratedAddress EthGenerateAddress(string walletXpub, int index);

        PrivKey EthGenerateAddressPrivateKey(PrivKeyRequest privKeyRequest);

        string EthSignTransaction(Transaction transaction, Account account);
    }
}