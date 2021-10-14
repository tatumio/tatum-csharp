using System;

using Tatum.Model;


namespace Tatum
{
    public class Wallets
    {
        public string Mnemonic { get; set; }
        public string XPub { get; set; }
        public string PrivateKey { get; set; }
        public string Address { get; set; }
        public string secret { get; set; }



        public static Wallets Create(Currency currency, string mnemonic, bool testnet)
        {
            switch (currency)
            {
                case Currency.BTC:
                    IBitcoinClient bitcoinClient = new BitcoinClient("");
                    return bitcoinClient.CreateWallet(mnemonic, testnet);

                case Currency.BCH:
                    IBitcoinCashClient bitcoinCashClient = new BitcoinCashClient("");
                    return bitcoinCashClient.CreateWallet(mnemonic, testnet);

                case Currency.LTC:
                    ILitecoinClient litecoinClient = new LitecoinClient("");
                    return litecoinClient.CreateWallet(mnemonic, testnet);

                case Currency.DOGE:
                    IDogecoinClient dogeClient = new DogeClient("");
                    return dogeClient.CreateWallet(mnemonic, testnet);

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
                case Currency.BSC:
                case Currency.MATIC:
                case Currency.XDC:
                case Currency.ONE:
                case Currency.CELO:
                    IEthereumClient ethereumClient = new EthereumClient("");
                    return ethereumClient.CreateWallet(mnemonic, testnet);

                case Currency.VET:
                    IVechainClient veChainClient = new VechainClient("");
                    return veChainClient.CreateWallet(mnemonic, testnet);

                case Currency.XLM:
                    IXlmClient xlmClient = new XLMClient("");
                    return xlmClient.CreateWallet();

                case Currency.QTUM:
                    IQtumClient qtumClient = new QtumClient("");
                    return qtumClient.CreateWallet(mnemonic, testnet);

                case Currency.XRP:
                case Currency.NEO:
                case Currency.BNB:
                default:
                    throw new NotImplementedException();
            }
        }

        public static string GeneratePrivateKey(Currency currency, string mnemonic, int index, bool testnet)
        {
            switch (currency)
            {
                case Currency.BTC:
                    IBitcoinClient bitcoinClient = new BitcoinClient("");
                    return bitcoinClient.GeneratePrivateKey(mnemonic,index, testnet);

                case Currency.BCH:
                    IBitcoinCashClient bitcoinCashClient = new BitcoinCashClient("");
                    return bitcoinCashClient.GeneratePrivateKey(mnemonic,index, testnet);

                case Currency.LTC:
                    ILitecoinClient litecoinClient = new LitecoinClient("");
                    return litecoinClient.GeneratePrivateKey(mnemonic, index, testnet);

                case Currency.DOGE:
                    IDogecoinClient dogeClient = new DogeClient("");
                    return dogeClient.GeneratePrivateKey(mnemonic, index, testnet);

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
                case Currency.BSC:
                case Currency.MATIC:
                case Currency.XDC:
                case Currency.ONE:
                case Currency.CELO:
                    IEthereumClient ethereumClient = new EthereumClient("");
                    return ethereumClient.GeneratePrivateKey(mnemonic, index, testnet);

                case Currency.VET:
                    IVechainClient veChainClient = new VechainClient("");
                    return veChainClient.GeneratePrivateKey(mnemonic, index, testnet);

              

                case Currency.QTUM:
                    IQtumClient qtumClient = new QtumClient("");
                    return qtumClient.GeneratePrivateKey(mnemonic, index, testnet);

                case Currency.XRP:
                case Currency.NEO:
                case Currency.BNB:
                default:
                    throw new NotImplementedException();
            }
        }

        public static string GenerateAddress(Currency currency, string xPubString, int index, bool testnet)
        {
            switch (currency)
            {
                case Currency.BTC:
                    IBitcoinClient bitcoinClient = new BitcoinClient("");
                    return bitcoinClient.GenerateAddress(xPubString, index, testnet);

                case Currency.BCH:
                    IBitcoinCashClient bitcoinCashClient = new BitcoinCashClient("");
                    return bitcoinCashClient.GenerateAddress(xPubString,index, testnet);

                case Currency.LTC:
                    ILitecoinClient litecoinClient = new LitecoinClient("");
                    return litecoinClient.GenerateAddress(xPubString, index, testnet);

                case Currency.DOGE:
                    IDogecoinClient dogeClient = new DogeClient("");
                    return dogeClient.GenerateAddress(xPubString, index, testnet);

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
                case Currency.BSC:
                case Currency.MATIC:
                case Currency.XDC:
                case Currency.ONE:
                case Currency.CELO:
                    IEthereumClient ethereumClient = new EthereumClient("");
                    return ethereumClient.GenerateAddress(xPubString, index, testnet);

                case Currency.VET:
                    IVechainClient veChainClient = new VechainClient("");
                    return veChainClient.GenerateAddress(xPubString, index, testnet);              

                case Currency.QTUM:
                    IQtumClient qtumClient = new QtumClient("");
                    return qtumClient.GenerateAddress(xPubString, index, testnet);

                case Currency.XRP:
                case Currency.NEO:
                case Currency.BNB:
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
