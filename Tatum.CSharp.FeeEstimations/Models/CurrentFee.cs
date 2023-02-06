using System;

namespace Tatum.CSharp.FeeEstimations.Models
{
    public class CurrentFee
    {
        public string FastGasPriceGwei { get; set; }
        public string MediumGasPriceGwei { get; set; }
        public string SlowGasPriceGwei { get; set; }
        public string BaseFeeGwei { get; set; }
        public DateTime LastRecalculated { get; set; }
        public int BasedOnBlockNumber { get; set; }
    }
}

