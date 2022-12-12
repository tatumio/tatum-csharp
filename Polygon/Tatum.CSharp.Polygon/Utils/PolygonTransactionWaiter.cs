using System.Threading.Tasks;
using Tatum.CSharp.Polygon.Clients;
using Tatum.CSharp.Polygon.Core.Client;
using Tatum.CSharp.Polygon.Core.Model;
using Tatum.CSharp.Utils;

namespace Tatum.CSharp.Polygon.Utils
{
    public class PolygonTransactionWaiter : TransactionWaiter<PolygonTx>
    {
        private const string NotFoundTransactionSearchString = ".tx.not.found";
        
        public PolygonTransactionWaiter(IPolygonClient polygonClient) 
            : base(
                polygonClient.PolygonBlockchain.PolygonGetTransactionAsync, 
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