using System.Threading.Tasks;
using Tatum.CSharp.Bsc.Clients;
using Tatum.CSharp.Bsc.Core.Client;
using Tatum.CSharp.Bsc.Core.Model;
using Tatum.CSharp.Utils;

namespace Tatum.CSharp.Bsc.Utils
{
    public class BscTransactionWaiter : TransactionWaiter<BscTx>
    {
        private const string NotFoundTransactionSearchString = ".tx.not.found";
        
        public BscTransactionWaiter(IBscClient bscClient) 
            : base(
                (txId, token) => bscClient.BscBlockchain.BscGetTransactionAsync(txId, cancellationToken: token), 
                tx => tx.Status || tx.BlockNumber != null)
        {
            ExceptionHandler = exception =>
            {
                if (exception is ApiException apiException 
                    && apiException.Message.Contains(NotFoundTransactionSearchString)) return;

                throw exception;
            };
        }
    }
}