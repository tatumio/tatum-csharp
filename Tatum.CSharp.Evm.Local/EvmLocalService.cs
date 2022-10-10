using NBitcoin;
using Nethereum.HdWallet;
using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Web3.Accounts;
using Tatum.CSharp.Core.Model;
using Transaction = Nethereum.RPC.Eth.DTOs.Transaction;
using Wallet = Tatum.CSharp.Core.Model.Wallet;

namespace Tatum.CSharp.Evm.Local
{
    public class EvmLocalService : IEvmLocalService
    {
        private readonly bool _isTestNet;
        private const string TestNetPath = "m/44'/1'/0'/0";
        private const string MainNetPath = "m/44'/60'/0'/0";

        public EvmLocalService()
        {
            _isTestNet = false;
        }
        
        public EvmLocalService(bool isTestNet)
        {
            _isTestNet = isTestNet;
        }

        /// <inheritdoc />
        public Wallet GenerateWallet()
        {
            var mnemonic = GenerateMnemonic();
            return GenerateWallet(mnemonic);
        }

        /// <inheritdoc />
        public Wallet GenerateWallet(string mnemonic)
        {
            var wallet = CreateHdWallet(mnemonic);

            return new Wallet()
            {
                Mnemonic = mnemonic,
                Xpub = wallet.GetMasterExtPubKey().ToString(Network.Main)
            };
        }

        /// <inheritdoc />
        public GeneratedAddress GenerateAddress(string walletXpub, int index)
        {
            var bitcoinExtPubKey = new BitcoinExtPubKey(walletXpub, Network.Main);
            var wallet = new PublicWallet(bitcoinExtPubKey.ExtPubKey);
            
            return new GeneratedAddress
            {
                Address = wallet.GetAddress(index)
            };
        }

        /// <inheritdoc />
        public PrivKey GenerateAddressPrivateKey(PrivKeyRequest privKeyRequest)
        {
            var wallet = new Nethereum.HdWallet.Wallet(privKeyRequest.Mnemonic,null, _isTestNet ? TestNetPath : MainNetPath);

            var privKey = wallet.GetPrivateKey(privKeyRequest.Index);
            
            return new PrivKey()
            {
                Key = privKey.ToHex(true)
            };
        }

        /// <inheritdoc />
        public string SignTransaction(Transaction transaction, Account account)
        {
            var transactionManager = new AccountOfflineTransactionSigner();
            var transactionInput = transaction.ConvertToTransactionInput();
            
            return transactionManager.SignTransaction(account, transactionInput);
        }

        private static string GenerateMnemonic()
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