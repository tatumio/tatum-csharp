using System;
using Tatum.Clients;
using Tatum.Model;

namespace Tatum
{
    public class Wallet
    {
        public string Mnemonic { get; set; }
        public string XPub { get; set; }
        public string PrivateKey { get; set; }
        public string Address { get; set; }

        /// <summary>
        /// Generate wallet
        /// </summary>
        /// <param name="currency"></param>
        /// <param name="mnemonic"></param>
        /// <param name="testnet">testnet or mainnet version of address</param>
        /// <returns>Wallet including xPub</returns>
        public static Wallet Create(Currency currency, string mnemonic, bool testnet)
        {
            switch (currency)
            {
                case Currency.BTC:
                    IBitcoinClient bitcoinClient = new BitcoinClient();
                    return bitcoinClient.CreateWallet(mnemonic, testnet);

                case Currency.BCH:
                    IBitcoinCashClient bitcoinCashClient = new BitcoinCashClient();
                    return bitcoinCashClient.CreateWallet(mnemonic, testnet);

                case Currency.LTC:
                    ILitecoinClient litecoinClient = new LitecoinClient();
                    return litecoinClient.CreateWallet(mnemonic, testnet);

                case Currency.ETH:
                case Currency.USDT:
                case Currency.LEO:
                case Currency.LINK:
                case Currency.UNI:
                case Currency.FREE:
                case Currency.MKR:
                case Currency.USDC:
                case Currency.BAT:
                case Currency.TUSD:
                case Currency.PAX:
                case Currency.PLTC:
                case Currency.XCON:
                case Currency.MMY:
                case Currency.PAXG:
                    IEthereumClient ethereumClient = new EthereumClient();
                    return ethereumClient.CreateWallet(mnemonic, testnet);
                
                case Currency.VET:
                    IVeChainClient veChainClient = new VeChainClient();
                    return veChainClient.CreateWallet(mnemonic, testnet);

                case Currency.XLM:
                    IXlmClient xlmClient = new XlmClient();
                    return xlmClient.CreateWallet();

                case Currency.XRP:
                case Currency.NEO:
                case Currency.BNB:
                default:
                    throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Generate private key from mnemonic seed
        /// </summary>
        /// <param name="currency"></param>
        /// <param name="mnemonic">mnemonic to generate private key from</param>
        /// <param name="index">derivation index of private key to generate</param>
        /// <param name="testnet">testnet or mainnet version of address</param>
        /// <returns>blockchain private key</returns>
        public static string GeneratePrivateKey(Currency currency, string mnemonic, int index, bool testnet)
        {
            switch (currency)
            {
                case Currency.BTC:
                    IBitcoinClient bitcoinClient = new BitcoinClient();
                    return bitcoinClient.GeneratePrivateKey(mnemonic, index, testnet);

                case Currency.BCH:
                    IBitcoinCashClient bitcoinCashClient = new BitcoinCashClient();
                    return bitcoinCashClient.GeneratePrivateKey(mnemonic, index, testnet);

                case Currency.LTC:
                    ILitecoinClient litecoinClient = new LitecoinClient();
                    return litecoinClient.GeneratePrivateKey(mnemonic, index, testnet);

                case Currency.ETH:
                case Currency.USDT:
                case Currency.LEO:
                case Currency.LINK:
                case Currency.UNI:
                case Currency.FREE:
                case Currency.MKR:
                case Currency.USDC:
                case Currency.BAT:
                case Currency.TUSD:
                case Currency.PAX:
                case Currency.PLTC:
                case Currency.XCON:
                case Currency.MMY:
                case Currency.PAXG:
                    IEthereumClient ethereumClient = new EthereumClient();
                    return ethereumClient.GeneratePrivateKey(mnemonic, index, testnet);

                case Currency.VET:
                    IVeChainClient veChainClient = new VeChainClient();
                    return veChainClient.GeneratePrivateKey(mnemonic, index, testnet);

                case Currency.XLM:
                case Currency.XRP:
                case Currency.NEO:
                case Currency.BNB:
                default:
                    throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Generate address
        /// </summary>
        /// <param name="xPubString">extended public key to generate address from</param>
        /// <param name="index">derivation index of address to generate. Up to 2^31 addresses can be generated</param>
        /// <param name="testnet">testnet or mainnet version of address</param>
        /// <returns>blockchain address</returns>
        public static string GenerateAddress(Currency currency, string xPubString, int index, bool testnet)
        {
            switch (currency)
            {
                case Currency.BTC:
                    IBitcoinClient bitcoinClient = new BitcoinClient();
                    return bitcoinClient.GenerateAddress(xPubString, index, testnet);

                case Currency.BCH:
                    IBitcoinCashClient bitcoinCashClient = new BitcoinCashClient();
                    return bitcoinCashClient.GenerateAddress(xPubString, index, testnet);

                case Currency.LTC:
                    ILitecoinClient litecoinClient = new LitecoinClient();
                    return litecoinClient.GenerateAddress(xPubString, index, testnet);

                case Currency.ETH:
                case Currency.USDT:
                case Currency.LEO:
                case Currency.LINK:
                case Currency.UNI:
                case Currency.FREE:
                case Currency.MKR:
                case Currency.USDC:
                case Currency.BAT:
                case Currency.TUSD:
                case Currency.PAX:
                case Currency.PLTC:
                case Currency.XCON:
                case Currency.MMY:
                case Currency.PAXG:
                    IEthereumClient ethereumClient = new EthereumClient();
                    return ethereumClient.GenerateAddress(xPubString, index, testnet);

                case Currency.VET:
                    IVeChainClient veChainClient = new VeChainClient();
                    return veChainClient.GenerateAddress(xPubString, index, testnet);

                case Currency.XLM:
                case Currency.XRP:
                case Currency.NEO:
                case Currency.BNB:
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
