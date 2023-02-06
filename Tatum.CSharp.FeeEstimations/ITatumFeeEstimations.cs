using System.Threading.Tasks;
using Tatum.CSharp.Core.Models;
using Tatum.CSharp.FeeEstimations.Models;
using Tatum.CSharp.FeeEstimations.Models.Requests;

namespace Tatum.CSharp.FeeEstimations
{
    public interface ITatumFeeEstimations
    {
        Task<CurrentFee> GetCurrentFee(Chain chain);

        Task<EstimatedFee> EstimateFeeForBlockchainTransaction(TransactionDataForFeeEstimation transactionDataForFeeEstimation);
    }
}

