using NBitcoin;
using System;
using Tatum.Blockchain;

namespace Tatum.Clients
{
    public partial class LitecoinClient : ILitecoinClient
    {
        Wallet ILitecoinClient.CreateWallet(string mnemonic, bool testnet)
        {
            var xPub = new Mnemonic(mnemonic)
                .DeriveExtKey()
                .Derive(new KeyPath(testnet ? Constants.TestKeyDerivationPath : Constants.LtcKeyDerivationPath))
                .Neuter();

            return new Wallet
            {
                Mnemonic = mnemonic,
                XPub = xPub.ToString(testnet ? LitecoinTatum.Instance.Testnet : LitecoinTatum.Instance.Mainnet)
            };
        }

        string ILitecoinClient.GeneratePrivateKey(string mnemonic, int index, bool testnet)
        {
            return new Mnemonic(mnemonic)
                .DeriveExtKey()
                .Derive(new KeyPath(testnet ? Constants.TestKeyDerivationPath : Constants.LtcKeyDerivationPath))
                .Derive(Convert.ToUInt32(index))
                .PrivateKey
                .GetWif(testnet ? LitecoinTatum.Instance.Testnet : LitecoinTatum.Instance.Mainnet)
                .ToString();
        }

        string ILitecoinClient.GenerateAddress(string xPubString, int index, bool testnet)
        {
            return ExtPubKey.Parse(xPubString, testnet ? LitecoinTatum.Instance.Testnet : LitecoinTatum.Instance.Mainnet)
                .Derive(Convert.ToUInt32(index))
                .PubKey
                .GetAddress(ScriptPubKeyType.Legacy, testnet ? LitecoinTatum.Instance.Testnet : LitecoinTatum.Instance.Mainnet)
                .ToString();
        }
    }
}
