using Nethereum.Web3.Accounts;
using Tatum.CSharp.Core.Model;
using Transaction = Nethereum.RPC.Eth.DTOs.Transaction;

namespace Tatum.CSharp.Evm.Local
{
    public interface IEvmLocalService
    {
        Wallet GenerateWallet();

        Wallet GenerateWallet(string mnemonic);

        GeneratedAddress GenerateAddress(string walletXpub, int index);

        PrivKey GenerateAddressPrivateKey(PrivKeyRequest privKeyRequest);

        string SignTransaction(Transaction transaction, Account account);
    }
}