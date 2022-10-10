using NBitcoin;
using Tatum.CSharp.Core.Model;
using Wallet = Tatum.CSharp.Core.Model.Wallet;

namespace Tatum.CSharp.Bitcoin.Local
{
    public class BitcoinLocalService : IBitcoinLocalService
    {
        private readonly bool _isTestNet;
        private const string TestNetPath = "m/44'/1'/0'/0";
        private const string MainNetPath = "m/44'/60'/0'/0";

        public BitcoinLocalService()
        {
            _isTestNet = false;
        }
        
        public BitcoinLocalService(bool isTestNet)
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
            var extPubKey = new Mnemonic(mnemonic)
                .DeriveExtKey()
                .Derive(new KeyPath(_isTestNet ? TestNetPath : MainNetPath))
                .Neuter()
                .ToString(_isTestNet ? Network.Main : Network.TestNet);
            
            return new Wallet
            {
                Mnemonic = mnemonic,
                Xpub = extPubKey
            };
        }

        /// <inheritdoc />
        public GeneratedAddress GenerateAddress(string walletXpub, int index)
        {
            var bitcoinExtPubKey = new BitcoinExtPubKey(walletXpub, _isTestNet ? Network.TestNet : Network.Main);

            var address = bitcoinExtPubKey.Derive((uint)index).GetPublicKey().GetAddress(ScriptPubKeyType.Segwit, _isTestNet ? Network.TestNet : Network.Main);
            
            return new GeneratedAddress
            {
                Address = address.ToString()
            };
        }

        /// <inheritdoc />
        public PrivKey GenerateAddressPrivateKey(PrivKeyRequest privKeyRequest)
        {
            var extKey = new Mnemonic(privKeyRequest.Mnemonic).DeriveExtKey();

            return new PrivKey()
            {
                Key = extKey.PrivateKey.ToString(_isTestNet ? Network.TestNet : Network.Main)
            };
        }

        /// <inheritdoc />
        public string SignTransaction(Transaction transaction, string privKey)
        {
            var bitcoinPrivateKey = new BitcoinSecret(privKey, _isTestNet ? Network.TestNet : Network.Main);

            var signature = bitcoinPrivateKey.PrivateKey.Sign(transaction.GetHash());

            return signature.ToString();
        }

        private static string GenerateMnemonic()
        {
            var mnemonic = new Mnemonic(Wordlist.English, WordCount.TwentyFour);

            return string.Join(" ", mnemonic.Words);
        }
    }
}