using NBitcoin;
using NBitcoin.Altcoins;
using System;

namespace Tatum.Clients
{
    public partial class BitcoinCashClient : IBitcoinCashClient
    {
        /// <summary>
        /// Generate BitcoinCash wallet
        /// </summary>
        /// <param name="mnemonic"></param>
        /// <param name="testnet">testnet or mainnet version of address</param>
        /// <returns></returns>
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

        /// <summary>
        /// Generate BitcoinCash private key from mnemonic seed
        /// </summary>
        /// <param name="mnemonic">mnemonic to generate private key from</param>
        /// <param name="index">derivation index of private key to generate</param>
        /// <param name="testnet">testnet or mainnet version of address</param>
        /// <returns>blockchain private key</returns>
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

        /// <summary>
        /// Generate BitcoinCash address
        /// </summary>
        /// <param name="xPubString">extended public key to generate address from</param>
        /// <param name="index">derivation index of address to generate. Up to 2^32 addresses can be generated</param>
        /// <param name="testnet">testnet or mainnet version of address</param>
        /// <returns>blockchain address</returns>
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
