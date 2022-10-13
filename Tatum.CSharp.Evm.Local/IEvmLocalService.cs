using Nethereum.Web3.Accounts;
using Tatum.CSharp.Core.Model;
using Transaction = Nethereum.RPC.Eth.DTOs.Transaction;

namespace Tatum.CSharp.Evm.Local
{
    public interface IEvmLocalService
    {
        /// <summary>
        /// Generates a BIP44 compatible EVM wallet with the derivation path m/44'/60'/0'/0.
        /// </summary>
        Wallet GenerateWallet();

        /// <summary>
        /// Generates a BIP44 compatible EVM wallet with the derivation path m/44'/60'/0'/0.
        /// </summary>
        /// <param name="mnemonic">Mnemonic to use for generating extended public and private keys.</param>
        Wallet GenerateWallet(string mnemonic);

        /// <summary>
        /// Generates an EVM account deposit address from an Extended public key.
        /// </summary>
        /// <param name="walletXpub">Extended public key of wallet.</param>
        /// <param name="index">Derivation index of the address to be generated.</param>
        /// <returns></returns>
        GeneratedAddressEth GenerateAddress(string walletXpub, int index);

        /// <summary>
        /// Generates the private key of an address from a mnemonic for a given derivation path index.
        /// </summary>
        PrivKey GenerateAddressPrivateKey(PrivKeyRequest privKeyRequest);

        /// <summary>
        /// Signs transaction locally.
        /// </summary>
        /// <param name="transaction"><see cref="Transaction"/> data to be signed.</param>
        /// <param name="account"><see cref="Account"/> instantiated with private key and chainId.</param>
        /// <remarks>ChainId for EVM is 11155111.</remarks>
        /// <returns>Raw signed transaction string.</returns>
        string SignTransaction(Transaction transaction, Account account);
    }
}