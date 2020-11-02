using NBitcoin;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Tatum.Model;
using Tatum.Model.Requests;
using Tatum.Model.Responses;

namespace Tatum.Clients
{
    public partial class BitcoinClient : IBitcoinClient
    {
        Task<string> IBitcoinClient.SignKmsTransaction(TransactionKms tx, List<string> privateKeys, bool testnet)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Sign Bitcoin transaction with private keys locally. Nothing is broadcasted to the blockchain.
        /// </summary>        
        /// <param name="body">content of the transaction to broadcast</param>
        /// <param name="testnet">testnet or mainnet version</param>
        /// <returns>Transaction data to be broadcast to blockchain.</returns>
        Task<string> IBitcoinClient.PrepareSignedTransaction(TransferBtcBasedBlockchain body, bool testnet)
        {
            return PrepareSignedTransaction(testnet ? Network.TestNet : Network.Main, body, Currency.BTC);
        }

        /// <summary>
        /// Send Bitcoin transaction to the blockchain. This method broadcasts signed transaction to the blockchain.
        /// This operation is irreversible.
        /// </summary>
        /// <param name="body">content of the transaction to broadcast</param>
        /// <param name="testnet">testnet or mainnet version</param>
        /// <returns>transaction id of the transaction in the blockchain</returns>
        public async Task<TransactionHash> SendTransaction(TransferBtcBasedBlockchain body, bool testnet)
        {
            string txData = await (this as IBitcoinClient).PrepareSignedTransaction(body, testnet);
            var broadcastRequest = new BroadcastRequest
            {
                TxData = txData
            };

            return await (this as IBitcoinClient).Broadcast(broadcastRequest);
        }


        private async Task<string> PrepareSignedTransaction(Network network, TransferBtcBasedBlockchain body, Currency currency)
        {
            var validationContext = new ValidationContext(body);
            Validator.ValidateObject(body, validationContext);

            return string.Empty;
        }
    }
}
