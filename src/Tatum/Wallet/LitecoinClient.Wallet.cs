using NBitcoin;
using System;
using Tatum.Blockchain;

namespace Tatum.Clients
{
    public partial class LitecoinClient : ILitecoinClient
    {
        /// <summary>
        /// Generate Litecoin wallet
        /// </summary>
        /// <param name="mnemonic"></param>
        /// <param name="testnet">testnet or mainnet version of address</param>
        /// <returns></returns>
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

        /// <summary>
        /// Generate Litecoin private key from mnemonic seed
        /// </summary>
        /// <param name="mnemonic">mnemonic to generate private key from</param>
        /// <param name="index">derivation index of private key to generate</param>
        /// <param name="testnet">testnet or mainnet version of address</param>
        /// <returns>blockchain private key</returns>
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

        /// <summary>
        /// Generate Litecoin address
        /// </summary>
        /// <param name="xPubString">extended public key to generate address from</param>
        /// <param name="index">derivation index of address to generate. Up to 2^32 addresses can be generated</param>
        /// <param name="testnet">testnet or mainnet version of address</param>
        /// <returns>blockchain address</returns>
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
