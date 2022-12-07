using NBitcoin;
using Tatum.CSharp.Bitcoin.Local.Models;

namespace Tatum.CSharp.Bitcoin.Local
{
    public class BitcoinLocalService : IBitcoinLocalService
    {
        private const string TestNetPath = "m/44'/1'/0'/0";
        private const string MainNetPath = "m/44'/60'/0'/0";

        private readonly Network _targetNetwork;
        private readonly string _targetDerivationPath;

        public BitcoinLocalService() : this(false)
        {
        }
        
        public BitcoinLocalService(bool isTestNet)
        {
            _targetNetwork = isTestNet ? Network.TestNet : Network.Main;
            _targetDerivationPath = isTestNet ? TestNetPath : MainNetPath;
        }

        /// <inheritdoc />
        public WalletLocal GenerateWallet()
        {
            var mnemonic = new Mnemonic(Wordlist.English, WordCount.TwentyFour);

            var extPubKey = mnemonic
                .DeriveExtKey()
                .Derive(new KeyPath(_targetDerivationPath))
                .Neuter()
                .ToString(_targetNetwork);
            
            return new WalletLocal(string.Join(" ", mnemonic.Words), extPubKey);
        }

        /// <inheritdoc />
        public WalletLocal GenerateWallet(string mnemonic)
        {
            var extPubKey = new Mnemonic(mnemonic)
                .DeriveExtKey()
                .Derive(new KeyPath(_targetDerivationPath))
                .Neuter()
                .ToString(_targetNetwork);
            
            return new WalletLocal(mnemonic, extPubKey);
        }

        /// <inheritdoc />
        public GeneratedAddressBtcLocal GenerateAddress(string walletXpub, int index)
        {
            var bitcoinExtPubKey = new BitcoinExtPubKey(walletXpub, _targetNetwork);

            var address = bitcoinExtPubKey
                .Derive((uint)index)
                .GetPublicKey()
                .GetAddress(ScriptPubKeyType.Segwit, _targetNetwork)
                .ToString();
            
            return new GeneratedAddressBtcLocal(address);
        }

        /// <inheritdoc />
        public PrivKeyLocal GenerateAddressPrivateKey(PrivKeyRequestLocal privKeyRequest)
        {
            var privKey = new Mnemonic(privKeyRequest.Mnemonic)
                .DeriveExtKey()
                .Derive(new KeyPath(_targetDerivationPath))
                .Derive((uint)privKeyRequest.Index)
                .PrivateKey
                .ToString(_targetNetwork);

            return new PrivKeyLocal(privKey);
        }

        /// <inheritdoc />
        public BitcoinSecret CreateBitcoinSecret(string privateKey, Network network)
        {
            return new BitcoinSecret(privateKey, network);
        }
    }
}