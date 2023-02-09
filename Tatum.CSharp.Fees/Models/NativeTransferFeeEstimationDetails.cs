using Tatum.CSharp.Core.Models;

namespace Tatum.CSharp.Fees.Models
{
    public class NativeTransferFeeEstimationDetails
    {
        public Chain Chain { get; set; }

        public string From { get; set; }

        public string To { get; set; }

        public string Value { get; set; }
    }
}