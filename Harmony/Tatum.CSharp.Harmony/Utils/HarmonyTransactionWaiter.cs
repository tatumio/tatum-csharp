using System.Threading.Tasks;
using Tatum.CSharp.Harmony.Clients;
using Tatum.CSharp.Harmony.Core.Client;
using Tatum.CSharp.Harmony.Core.Model;
using Tatum.CSharp.Utils;

namespace Tatum.CSharp.Harmony.Utils
{
    public class HarmonyTransactionWaiter : TransactionWaiter<OneTx>
    {
        private const string NotFoundTransactionSearchString = ".tx.not.found";
        
        public HarmonyTransactionWaiter(IHarmonyClient harmonyClient) 
            : base(
                (txId, token) => harmonyClient.HarmonyBlockchain.OneGetTransactionAsync(txId, cancellationToken: token), 
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