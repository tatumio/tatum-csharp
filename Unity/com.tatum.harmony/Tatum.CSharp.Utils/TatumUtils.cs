using System.Threading.Tasks;

namespace Tatum.CSharp.Utils
{
    public class TatumUtils<TTransaction> : ITatumUtils
    {
        private readonly TransactionWaiter<TTransaction> _transactionWaiter;

        public TatumUtils(TransactionWaiter<TTransaction> transactionWaiter)
        {
            _transactionWaiter = transactionWaiter;
        }
        
        public async Task WaitForTransactionAsync(string transactionHash)
        {
            await _transactionWaiter.WaitForTransactionAsync(transactionHash).ConfigureAwait(false);
        }
    }
}