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
        
        public Wallet EthGenerateWallet()
        {
            var mnemonic = GenerateMnemonic();
            return EthGenerateWallet(mnemonic);
        }

        public Wallet EthGenerateWallet(string mnemonic)
        {
            var wallet = CreateHdWallet(mnemonic);

            return new Wallet()
            {
                Mnemonic = mnemonic,
                Xpub = wallet.GetMasterExtPubKey().ToString(Network.Main)
            };
        }

        public GeneratedAddress EthGenerateAddress(string walletXpub, int index)
        {
            var bitcoinExtPubKey = new BitcoinExtPubKey(walletXpub, Network.Main);
            var wallet = new PublicWallet(bitcoinExtPubKey.ExtPubKey);
            
            return new GeneratedAddress
            {
                Address = wallet.GetAddress(index)
            };
        }

        public PrivKey EthGenerateAddressPrivateKey(PrivKeyRequest privKeyRequest)
        {
            var wallet = new Nethereum.HdWallet.Wallet(privKeyRequest.Mnemonic,null, _isTestNet ? TestNetPath : MainNetPath);

            var privKey = wallet.GetPrivateKey(privKeyRequest.Index);
            
            return new PrivKey()
            {
                Key = privKey.ToHex(true)
            };
        }

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