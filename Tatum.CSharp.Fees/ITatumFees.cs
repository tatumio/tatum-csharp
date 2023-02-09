using System.Collections.Generic;
using System.Threading.Tasks;
using Tatum.CSharp.Core.Models;
using Tatum.CSharp.Fees.Models;

namespace Tatum.CSharp.Fees
{
    public interface ITatumFees
    {
        Task<Dictionary<Chain, ChainCurrentFee>> GetCurrent(IEnumerable<Chain> chains);
        
        Task<ChainCurrentFee> GetCurrent(Chain chain);

        Task<NativeTransferFeeEstimation> Estimate(IEnumerable<NativeTransferFeeEstimationDetails> nativeTransferFeeEstimationDetails);
        
        Task<NativeTransferFeeEstimation> Estimate(NativeTransferFeeEstimationDetails nativeTransferFeeEstimationDetails);
    }
}

