using NBitcoin;
using Tatum.CSharp.Core.Model;
using Wallet = Tatum.CSharp.Core.Model.Wallet;

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
        public Wallet GenerateWallet()
        {
            var mnemonic = new Mnemonic(Wordlist.English, WordCount.TwentyFour);

            var extPubKey = mnemonic
                .DeriveExtKey()
                .Derive(new KeyPath(_targetDerivationPath))
                .Neuter()
                .ToString(_targetNetwork);
            
            return new Wallet(string.Join(" ", mnemonic.Words), extPubKey);
        }

        /// <inheritdoc />
        public Wallet GenerateWallet(string mnemonic)
        {
            var extPubKey = new Mnemonic(mnemonic)
                .DeriveExtKey()
                .Derive(new KeyPath(_targetDerivationPath))
                .Neuter()
                .ToString(_targetNetwork);
            
            return new Wallet(mnemonic, extPubKey);
        }

        /// <inheritdoc />
        public GeneratedAddressBtc GenerateAddress(string walletXpub, int index)
        {
            var bitcoinExtPubKey = new BitcoinExtPubKey(walletXpub, _targetNetwork);

            var address = bitcoinExtPubKey
                .Derive((uint)index)
                .GetPublicKey()
                .GetAddress(ScriptPubKeyType.Segwit, _targetNetwork)
                .ToString();
            
            return new GeneratedAddressBtc(address);
        }

        /// <inheritdoc />
        public PrivKey GenerateAddressPrivateKey(PrivKeyRequest privKeyRequest)
        {
            var privKey = new Mnemonic(privKeyRequest.Mnemonic)
                .DeriveExtKey()
                .Derive(new KeyPath(_targetDerivationPath))
                .Derive((uint)privKeyRequest.Index)
                .PrivateKey
                .ToString(_targetNetwork);

            return new PrivKey(privKey);
        }

        /// <inheritdoc />
        public string SignTransaction(Transaction transaction, string privKey)
        {
            var bitcoinPrivateKey = new BitcoinSecret(privKey, _targetNetwork);

            var signature = bitcoinPrivateKey
                .PrivateKey
                .Sign(transaction.GetHash());

            transaction.Sign(bitcoinPrivateKey, new Coin(transaction, 0));

            return transaction.ToHex();
        }
    }
}