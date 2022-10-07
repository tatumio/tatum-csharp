using NBitcoin;
using Nethereum.HdWallet;
using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Web3.Accounts;
using Tatum.CSharp.Core.Model;
using Transaction = Nethereum.RPC.Eth.DTOs.Transaction;
using Wallet = Tatum.CSharp.Core.Model.Wallet;

namespace Tatum.CSharp.Ethereum.LocalServices
{
    public class EthereumLocalService : IEthereumLocalService
    {
        private readonly bool _isTestNet;
        private const string TestNetPath = "m/44'/1'/0'/0";
        private const string MainNetPath = "m/44'/60'/0'/0";

        public EthereumLocalService(bool isTestNet)
        {
            _isTestNet = isTestNet;
        }
        
        /// <summary>
        /// Generates a BIP44 compatible Ethereum wallet with the derivation path m/44'/60'/0'/0.
        /// </summary>
        public Wallet EthGenerateWallet()
        {
            var mnemonic = GenerateMnemonic();
            return EthGenerateWallet(mnemonic);
        }

        /// <summary>
        /// Generates a BIP44 compatible Ethereum wallet with the derivation path m/44'/60'/0'/0.
        /// </summary>
        /// <param name="mnemonic">Mnemonic to use for generating extended public and private keys.</param>
        public Wallet EthGenerateWallet(string mnemonic)
        {
            var wallet = CreateHdWallet(mnemonic);

            return new Wallet()
            {
                Mnemonic = mnemonic,
                Xpub = wallet.GetMasterExtPubKey().ToString(Network.Main)
            };
        }

        /// <summary>
        /// Generates an Ethereum account deposit address from an Extended public key.
        /// </summary>
        /// <param name="walletXpub">Extended public key of wallet.</param>
        /// <param name="index">Derivation index of the address to be generated.</param>
        /// <returns></returns>
        public GeneratedAddress EthGenerateAddress(string walletXpub, int index)
        {
            var bitcoinExtPubKey = new BitcoinExtPubKey(walletXpub, Network.Main);
            var wallet = new PublicWallet(bitcoinExtPubKey.ExtPubKey);
            
            return new GeneratedAddress
            {
                Address = wallet.GetAddress(index)
            };
        }

        /// <summary>
        /// Generates the private key of an address from a mnemonic for a given derivation path index.
        /// </summary>
        public PrivKey EthGenerateAddressPrivateKey(PrivKeyRequest privKeyRequest)
        {
            var wallet = new Nethereum.HdWallet.Wallet(privKeyRequest.Mnemonic,null, _isTestNet ? TestNetPath : MainNetPath);

            var privKey = wallet.GetPrivateKey(privKeyRequest.Index);
            
            return new PrivKey()
            {
                Key = privKey.ToHex(true)
            };
        }

        /// <summary>
        /// Signs transaction locally.
        /// </summary>
        /// <param name="transaction"><see cref="Transaction"/> data to be signed.</param>
        /// <param name="account"><see cref="Account"/> instantiated with private key and chainId.</param>
        /// <remarks>ChainId for Ethereum is 11155111.</remarks>
        /// <returns>Raw signed transaction string.</returns>
        public string EthSignTransaction(Transaction transaction, Account account)
        {
            var transactionManager = new AccountOfflineTransactionSigner();
            var transactionInput = transaction.ConvertToTransactionInput();
            
            return transactionManager.SignTransaction(account, transactionInput);
        }

        private string GenerateMnemonic()
        {
            var mnemonic = new Mnemonic(Wordlist.English, WordCount.TwentyFour);

            return string.Join(" ", mnemonic.Words);
        }

        private Nethereum.HdWallet.Wallet CreateHdWallet(string mnemonic)
        {
            return new Nethereum.HdWallet.Wallet(mnemonic, null, _isTestNet ? TestNetPath : MainNetPath);
        }
    }
}