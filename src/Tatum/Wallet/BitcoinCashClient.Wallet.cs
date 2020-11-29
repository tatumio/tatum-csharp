using NBitcoin;
using NBitcoin.Altcoins;
using System;

namespace Tatum.Clients
{
    public partial class BitcoinCashClient : IBitcoinCashClient
    {
        Wallet IBitcoinCashClient.CreateWallet(string mnemonic, bool testnet)
        {
            var xPub = new Mnemonic(mnemonic)
                .DeriveExtKey()
                .Derive(new KeyPath(Constants.BchKeyDerivationPath))
                .Neuter();

            return new Wallet
            {
                Mnemonic = mnemonic,
                XPub = xPub.ToString(testnet ? BCash.Instance.Testnet : BCash.Instance.Mainnet)
            };
        }

        string IBitcoinCashClient.GeneratePrivateKey(string mnemonic, int index, bool testnet)
        {
            return new Mnemonic(mnemonic)
                .DeriveExtKey()
                .Derive(new KeyPath(Constants.BchKeyDerivationPath))
                .Derive(Convert.ToUInt32(index))
                .PrivateKey
                .GetWif(testnet ? BCash.Instance.Testnet : BCash.Instance.Mainnet)
                .ToString();
        }

        string IBitcoinCashClient.GenerateAddress(string xPubString, int index, bool testnet)
        {
            return ExtPubKey.Parse(xPubString, testnet ? BCash.Instance.Testnet : BCash.Instance.Mainnet)
                .Derive(Convert.ToUInt32(index))
                .PubKey
                .GetAddress(ScriptPubKeyType.Legacy, testnet ? BCash.Instance.Testnet : BCash.Instance.Mainnet)
                .ToString();
        }
    }
}
