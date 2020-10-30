using NBitcoin;

namespace Tatum.Clients
{
    public partial class BitcoinClient : IBitcoinClient
    {
        Wallet IBitcoinClient.CreateWallet(string mnemonic, bool testnet)
        {
            var xPub = new Mnemonic(mnemonic)
                .DeriveExtKey()
                .Derive(new KeyPath(testnet ? Constants.TestKeyDerivationPath : Constants.BtcKeyDerivationPath))
                .Neuter();

            return new Wallet
            {
                Mnemonic = mnemonic,
                XPub = xPub.ToString(testnet ? Network.TestNet : Network.Main)
            };
        }
    }
}
