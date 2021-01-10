using System;
using Tatum.Clients;
using Tatum.Model;

namespace Tatum
{
    public class Wallet
    {
        public string Mnemonic { get; set; }
        public string XPub { get; set; }

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

                case Currency.XRP:
                case Currency.XLM:
                case Currency.NEO:
                case Currency.BNB:
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
