using System;
using System.Globalization;
using Tatum.CSharp.FeeEstimations.Models;
using Tatum.CSharp.FeeEstimations.Models.Responses;

namespace Tatum.CSharp.FeeEstimations.Mappers
{
    internal static class FeeMapper
    {
        public static CurrentFee Map(CurrentFeeResponse response)
        {
            return new CurrentFee
            {
                FastGasPriceGwei = WeiToGweiString(response.Fast),
                MediumGasPriceGwei = WeiToGweiString(response.Medium),
                SlowGasPriceGwei = WeiToGweiString(response.Slow),
                BaseFeeGwei = WeiToGweiString(response.BaseFee),
                LastRecalculated = DateTime.ParseExact(response.Time, "yyyy-MM-ddTHH:mm:ss.fffZ", CultureInfo.InvariantCulture),
                BasedOnBlockNumber = response.Block
            };
        }
        
        public static EstimatedFee Map(EstimatedFeeResponse response)
        {
            return new EstimatedFee
            {
                GasLimit = response.GasLimit.ToString(CultureInfo.InvariantCulture),
                GasPriceGwei = response.GasPrice.ToString(CultureInfo.InvariantCulture)
            };
        }
    
        private static string WeiToGweiString(decimal value)
        {
            return (value / 1_000_000_000).ToString(CultureInfo.InvariantCulture);
        }
    }
}

