using Tatum.CSharp.Ethereum.Clients;
using Tatum.CSharp.Ethereum.Core.Client;
using Tatum.CSharp.Ethereum.Core.Model;
using Tatum.CSharp.Utils;

namespace Tatum.CSharp.Ethereum.Utils
{
    public class EthereumTransactionWaiter : TransactionWaiter<EthTx>
    {
        private const string NotFoundTransactionSearchString = ".tx.not.found";
        
        public EthereumTransactionWaiter(IEthereumClient ethereumClient) 
            : base(
                async (txId, token) => await ethereumClient.EthereumBlockchain.EthGetTransactionAsync(txId, cancellationToken: token), 
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