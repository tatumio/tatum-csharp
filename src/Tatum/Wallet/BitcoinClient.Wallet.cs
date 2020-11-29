using NBitcoin;
using System;

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

        string IBitcoinClient.GeneratePrivateKey(string mnemonic, int index, bool testnet)
        {
            return new Mnemonic(mnemonic)
                .DeriveExtKey()
                .Derive(new KeyPath(testnet ? Constants.TestKeyDerivationPath : Constants.BtcKeyDerivationPath))
                .Derive(Convert.ToUInt32(index))
                .PrivateKey
                .GetWif(testnet ? Network.TestNet : Network.Main)
                .ToString();
        }

        string IBitcoinClient.GenerateAddress(string xPubString, int index, bool testnet)
        {
            return ExtPubKey.Parse(xPubString, testnet ? Network.TestNet : Network.Main)
                .Derive(Convert.ToUInt32(index))
                .PubKey
                .GetAddress(ScriptPubKeyType.Legacy, testnet ? Network.TestNet : Network.Main)
                .ToString();
        }
    }
}
