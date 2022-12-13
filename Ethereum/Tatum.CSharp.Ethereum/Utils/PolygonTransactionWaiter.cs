using Tatum.CSharp.Ethereum.Clients;
using Tatum.CSharp.Ethereum.Core.Client;
using Tatum.CSharp.Ethereum.Core.Model;
using Tatum.CSharp.Utils;

namespace Tatum.CSharp.Ethereum.Utils
{
    public class PolygonTransactionWaiter : TransactionWaiter<EthTx>
    {
        private const string NotFoundTransactionSearchString = ".tx.not.found";
        
        public PolygonTransactionWaiter(IEthereumClient ethereumClient) 
            : base(
                (txId, token) => ethereumClient.EthereumBlockchain.EthGetTransactionAsync(txId, cancellationToken: token), 
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