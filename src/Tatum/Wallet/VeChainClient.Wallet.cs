using NBitcoin;

namespace Tatum.Clients
{
    public partial class VeChainClient : IVeChainClient
    {
        Wallet IVeChainClient.CreateWallet(string mnemonic, bool testnet)
        {
            var wallet = new Nethereum.HdWallet.Wallet(mnemonic, "", testnet ? Constants.TestKeyDerivationPath : Constants.VetKeyDerivationPath);
            var xpub = wallet.GetMasterExtPubKey();

            return new Wallet
            {
                XPub = xpub.ToString(Network.Main),
                Mnemonic = mnemonic
            };
        }

        string IVeChainClient.GeneratePrivateKey(string mnemonic, int index, bool testnet)
        {
            var wallet = new Nethereum.HdWallet.Wallet(mnemonic, "", testnet ? Constants.TestKeyDerivationPath : Constants.VetKeyDerivationPath);

            return wallet.GetAccount(index).PrivateKey;
        }

        string IVeChainClient.GenerateAddress(string xPub, int index, bool testnet)
        {
            var extPubKey = ExtPubKey.Parse(xPub, Network.Main);

            var publicWallet = new Nethereum.HdWallet.PublicWallet(extPubKey);
            return publicWallet.GetAddress(index).ToLower();
        }
    }
}
