using System.Collections.Generic;
using Tatum.CSharp.Core.Models;

namespace Tatum.CSharp.Fees.Models
{
    public class NativeTransferFeeEstimation
    {
        public Dictionary<Chain, List<ChainNativeTransferFeeEstimation>> ChainNativeTransferFeeEstimations { get; set; } =
            new Dictionary<Chain, List<ChainNativeTransferFeeEstimation>>();
    }

    public class ChainNativeTransferFeeEstimation
    {
        public string GasLimit { get; set; }
        
        public GasPrice GasPrice { get; set; }
    }

    public class GasPrice
    {
        public string Slow { get; set; }
        public string Medium { get; set; }
        public string Fast { get; set; }
        public string BaseFee { get; set; }
        public string Unit { get; set; }
    }
}