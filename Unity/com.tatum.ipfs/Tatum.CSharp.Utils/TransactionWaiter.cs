using System;
using System.Threading;
using System.Threading.Tasks;

namespace Tatum.CSharp.Utils
{
    public abstract class TransactionWaiter<TTransaction>
    {
        private readonly Func<string, CancellationToken, Task<TTransaction>> _getTransactionFunc;
        private readonly Func<TTransaction, bool> _isCompletedFunc;

        /// <summary>
        /// Default retry time is 1 second.
        /// </summary>
        public TimeSpan DefaultRetryTime { get; } = TimeSpan.FromSeconds(1);
        
        /// <summary>
        /// Default timeout is 5 minutes.
        /// </summary>
        public TimeSpan DefaultTimeout { get; } = TimeSpan.FromMinutes(5);

        /// <summary>
        /// Custom exception handling can be set up here.
        /// </summary>
        public Action<Exception> ExceptionHandler { get; set; }

        protected TransactionWaiter(
            Func<string, CancellationToken, Task<TTransaction>> getTransactionFunc,
            Func<TTransaction, bool> isCompletedFunc)
        {
            _getTransactionFunc = getTransactionFunc;
            _isCompletedFunc = isCompletedFunc;
        }

        /// <summary>
        /// Waits for transaction to be completed.
        /// </summary>
        public virtual async Task WaitForTransactionAsync(string hash, TimeSpan timeout = default, TimeSpan retryTime = default, CancellationToken cancellationToken = default)
        {
            if (timeout == default)
                timeout = DefaultTimeout;

            if (retryTime == default)
                retryTime = DefaultRetryTime;
            
            if(cancellationToken == default)
                cancellationToken = CancellationToken.None;

            await WaitForTransactionInternalAsync(hash, timeout, retryTime, cancellationToken);
        }
        
        private async Task WaitForTransactionInternalAsync(string hash, TimeSpan timeout, TimeSpan retryTime, CancellationToken cancellationToken)
        {
            var timeoutCts = new CancellationTokenSource(timeout);

            var linkedTokenSource = CancellationTokenSource.CreateLinkedTokenSource(timeoutCts.Token, cancellationToken);
            
            while (true)
            {
                try
                {
                    var tx = await _getTransactionFunc(hash, linkedTokenSource.Token).ConfigureAwait(false);

                    if (_isCompletedFunc(tx))
                    {
                        break;
                    }

                    if (linkedTokenSource.IsCancellationRequested)
                    {
                        break;
                    }

                    await Task.Delay(retryTime, linkedTokenSource.Token).ConfigureAwait(false);
                }
                catch (TaskCanceledException)
                {
                    // we don't care about this exception, we just want to stop the loop
                    break;
                }
                catch (Exception exception)
                {
                    ExceptionHandler?.Invoke(exception);
                    
                    await Task.Delay(retryTime, linkedTokenSource.Token).ConfigureAwait(false);
                }
            }
        }
    }
}