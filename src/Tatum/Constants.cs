using System.Collections.Generic;
using Tatum.Model;

namespace Tatum
{
    public static class Constants
    {
        public const string BtcKeyDerivationPath = "m/44\'/0\'/0\'/0";
        public const string LtcKeyDerivationPath = "m/44\'/2\'/0\'/0";
        public const string BchKeyDerivationPath = "m/44\'/145\'/0\'/0";
        public const string EthKeyDerivationPath = "m/44\'/60\'/0\'/0";
        public const string VetKeyDerivationPath = "m/44\'/818\'/0\'/0";
        public const string TestKeyDerivationPath = "m/44\'/1\'/0\'/0";

        public static readonly Dictionary<Currency, string> ContractAddresses = new Dictionary<Currency, string>
        {
            { Currency.USDT, "0xdac17f958d2ee523a2206206994597c13d831ec7" },
            { Currency.LEO, "0x2af5d2ad76741191d15dfe7bf6ac92d4bd912ca3" },
            { Currency.LINK, "0x514910771af9ca656af840dff83e8264ecf986ca" },
            { Currency.UNI, "0x1f9840a85d5af5bf1d1762f925bdaddc4201f984" },
            { Currency.FREE, "0x2f141ce366a2462f02cea3d12cf93e4dca49e4fd" },
            { Currency.MKR, "0x9f8f72aa9304c8b593d555f12ef6589cc3a579a2" },
            { Currency.USDC, "0xa0b86991c6218b36c1d19d4a2e9eb0ce3606eb48" },
            { Currency.BAT, "0x0d8775f648430679a709e98d2b0cb6250d2887ef" },
            { Currency.TUSD, "0x0000000000085d4780B73119b644AE5ecd22b376" },
            { Currency.PAX, "0x8e870d67f660d95d5be530380d0ec0bd388289e1" },
            { Currency.PLTC, "0x429d83bb0dcb8cdd5311e34680adc8b12070a07f" },
            { Currency.XCON, "0x0f237d5ea7876e0e2906034d98fdb20d43666ad4" },
            { Currency.MMY, "0x385ddf50c3de724f6b8ecb41745c29f9dd3c6d75" },
            { Currency.PAXG, "0x45804880de22913dafe09f4980848ece6ecbaf78" }
        };

        public static readonly Dictionary<Currency, int> ContractDecimals = new Dictionary<Currency, int>
        {
            { Currency.USDT, 6 },
            { Currency.LEO, 18 },
            { Currency.LINK, 18 },
            { Currency.UNI, 18 },
            { Currency.FREE, 18 },
            { Currency.MKR, 18 },
            { Currency.USDC, 6 },
            { Currency.BAT, 18 },
            { Currency.TUSD, 18 },
            { Currency.PAX, 18 },
            { Currency.PLTC, 18 },
            { Currency.XCON, 18 },
            { Currency.MMY, 18 },
            { Currency.PAXG, 18 }
        };

        public const string TransferMethodAbi = @"
        {
            constant: false,
            inputs: [
                {
                    name: 'to',
                    type: 'address',
                },
                {
                    name: 'value',
                    type: 'uint256',
                },
            ],
            name: 'transfer',
            outputs: [
                {
                    name: '',
                    type: 'bool',
                },
            ],
            payable: false,
            stateMutability: 'nonpayable',
            type: 'function',
        }";
    }
}
