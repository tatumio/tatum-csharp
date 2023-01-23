using NBitcoin;
using Nethereum.HdWallet;
using Nethereum.Hex.HexConvertors.Extensions;
using Tatum.CSharp.Evm.Local.Models;

namespace Tatum.CSharp.Evm.Local
{
    public class EvmLocalService : IEvmLocalService
    {
        private const string TestNetPath = "m/44'/1'/0'/0";
        private const string MainNetPath = "m/44'/60'/0'/0";

        private readonly Network _targetNetwork;
        private readonly string _targetDerivationPath;

        public EvmLocalService() : this(false)
        {
        }
        
        public EvmLocalService(bool isTestNet)
        {
            _targetNetwork = Network.Main;
            _targetDerivationPath = isTestNet ? TestNetPath : MainNetPath;
        }

        /// <inheritdoc />
        public WalletLocal GenerateWallet()
        {
            var wallet = new Nethereum.HdWallet.Wallet(Wordlist.English, WordCount.TwentyFour, null, _targetDerivationPath);

            return new WalletLocal
            {
                Mnemonic = string.Join(" ", wallet.Words),
                Xpub = wallet.GetMasterExtPubKey().ToString(_targetNetwork)
            };
        }

        /// <inheritdoc />
        public WalletLocal GenerateWallet(string mnemonic)
        {
            var wallet = new Nethereum.HdWallet.Wallet(mnemonic, null, _targetDerivationPath);

            return new WalletLocal()
            {
                Mnemonic = mnemonic,
                Xpub = wallet.GetMasterExtPubKey().ToString(_targetNetwork)
            };
        }

        /// <inheritdoc />
        public GeneratedAddressEthLocal GenerateAddress(string walletXpub, int index)
        {
            var bitcoinExtPubKey = new BitcoinExtPubKey(walletXpub, _targetNetwork);
            var wallet = new PublicWallet(bitcoinExtPubKey.ExtPubKey);
            
            return new GeneratedAddressEthLocal
            {
                Address = wallet.GetAddress(index)
            };
        }

        /// <inheritdoc />
        public PrivKeyLocal GenerateAddressPrivateKey(PrivKeyRequestLocal privKeyRequest)
        {
            var wallet = new Nethereum.HdWallet.Wallet(privKeyRequest.Mnemonic,null, _targetDerivationPath);

            var privKey = wallet.GetPrivateKey(privKeyRequest.Index);
            
            return new PrivKeyLocal()
            {
                Key = privKey.ToHex(true)
            };
        }
    }
}