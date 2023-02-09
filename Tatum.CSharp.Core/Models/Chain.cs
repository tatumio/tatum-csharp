using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Tatum.CSharp.Core.Models
{
    public enum Chain
    {
        Ethereum = 1
    }
    
    public enum ChainAbbreviation
    {
        ETH = 1
    }

    public static class ChainMapper
    {
        private static readonly ReadOnlyDictionary<Chain, ChainAbbreviation> ChainName = new ReadOnlyDictionary<Chain, ChainAbbreviation>(new Dictionary<Chain, ChainAbbreviation>
        {
            {Chain.Ethereum, Models.ChainAbbreviation.ETH}
        });

        private static readonly ReadOnlyDictionary<ChainAbbreviation, Chain> ChainAbbreviation = new ReadOnlyDictionary<ChainAbbreviation, Chain>(new Dictionary<ChainAbbreviation, Chain>
        {
            {Models.ChainAbbreviation.ETH, Chain.Ethereum}
        });

        public static ChainAbbreviation GetChainAbbreviation(Chain chain)
        {
            return ChainName[chain];
        }

        public static Chain GetChainName(ChainAbbreviation chainAbbreviation)
        {
            return ChainAbbreviation[chainAbbreviation];
        }
    }
}