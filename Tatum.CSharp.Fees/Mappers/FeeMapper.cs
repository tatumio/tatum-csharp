using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Tatum.CSharp.Fees.Models;
using Tatum.CSharp.Fees.Models.Requests;
using Tatum.CSharp.Fees.Models.Responses;

namespace Tatum.CSharp.Fees.Mappers
{
    internal static class FeeMapper
    {
        public static ChainCurrentFee Map(CurrentFeeResponse response)
        {
            return new ChainCurrentFee
            {
                FastGasPriceGwei = WeiToGweiString(response.Fast),
                MediumGasPriceGwei = WeiToGweiString(response.Medium),
                SlowGasPriceGwei = WeiToGweiString(response.Slow),
                BaseFeeGwei = WeiToGweiString(response.BaseFee),
                LastRecalculated = DateTime.ParseExact(response.Time, "yyyy-MM-ddTHH:mm:ss.fffZ", CultureInfo.InvariantCulture),
                BasedOnBlockNumber = response.Block
            };
        }
        
        public static FeeEstimationDetails Map(NativeTransferFeeEstimationDetails nativeTransferFeeEstimationDetails)
        {
            return new FeeEstimationDetails
            {
                From = nativeTransferFeeEstimationDetails.From,
                To = nativeTransferFeeEstimationDetails.To,
                Amount = nativeTransferFeeEstimationDetails.Value
            };
        }
        
        public static List<ChainNativeTransferFeeEstimation> Map(EstimatedFeeResponse response)
        {
            return response.Results.Select(result => new ChainNativeTransferFeeEstimation
                {
                    GasLimit = result.Data.GasLimit,
                    GasPrice = new GasPrice
                    {
                        Slow = result.Data.Estimations.Safe,
                        Medium = result.Data.Estimations.Standard,
                        Fast = result.Data.Estimations.Fast,
                        BaseFee = result.Data.Estimations.BaseFee,
                        Unit = "Gwei"
                    }
                })
                .ToList();
        }
    
        private static string WeiToGweiString(decimal value)
        {
            return (value / 1_000_000_000).ToString(CultureInfo.InvariantCulture);
        }
    }
}

