using NBitcoin;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
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
            return PrepareSignedTransaction(testnet ? Network.TestNet : Network.Main, body);
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
            string txData = await (this as IBitcoinClient).PrepareSignedTransaction(body, testnet).ConfigureAwait(false);
            var broadcastRequest = new BroadcastRequest
            {
                TxData = txData
            };

            return await (this as IBitcoinClient).Broadcast(broadcastRequest).ConfigureAwait(false);
        }


        private async Task<string> PrepareSignedTransaction(Network network, TransferBtcBasedBlockchain body)
        {
            var validationContext = new ValidationContext(body);
            Validator.ValidateObject(body, validationContext);

            NBitcoin.Transaction transaction = network.CreateTransaction();
            List<BitcoinSecret> privateKeysToSign = new List<BitcoinSecret>();
            List<Coin> coinsToSpent = new List<Coin>();

            if (body.FromAddresses != null)
            {
                foreach (FromAddress fromAddress in body.FromAddresses)
                {
                    List<BitcoinTx> inputTxes = await (this as IBitcoinClient).GetTxForAccount(fromAddress.Address).ConfigureAwait(false);
                    foreach (BitcoinTx inputTx in inputTxes)
                    {
                        for (int i = 0; i < inputTx.Outputs.Count; i++)
                        {
                            if (inputTx.Outputs[i].Address == fromAddress.Address)
                            {
                                var secret = new BitcoinSecret(fromAddress.PrivateKey, network);
                                try
                                {
                                    BitcoinUtxo utxo = await (this as IBitcoinClient).GetUtxo(inputTx.Hash, i).ConfigureAwait(false);

                                    TxIn input = GetInputFromUtxo(secret, utxo, privateKeysToSign, coinsToSpent);
                                    transaction.Inputs.Add(input);
                                }
                                catch (Exception)
                                {
                                    // spent, unconfirmed or invalid utxos
                                }
                            }
                        }
                    }
                }
            }

            if (body.FromUtxos != null)
            {
                foreach (FromUtxo fromUtxo in body.FromUtxos)
                {
                    var secret = new BitcoinSecret(fromUtxo.PrivateKey, network);

                    try
                    {
                        BitcoinUtxo utxo = await (this as IBitcoinClient).GetUtxo(fromUtxo.TxHash, (int)fromUtxo.Index).ConfigureAwait(false);

                        TxIn input = GetInputFromUtxo(secret, utxo, privateKeysToSign, coinsToSpent);
                        transaction.Inputs.Add(input);
                    }
                    catch (Exception)
                    {
                        // spent, unconfirmed or invalid utxos
                    }
                }
            }

            foreach (To to in body.Tos)
            {
                var outputAddress = BitcoinAddress.Create(to.Address, network);
                transaction.Outputs.Add(new Money(to.Value, MoneyUnit.BTC), outputAddress.ScriptPubKey);
            }

            transaction.Sign(privateKeysToSign, coinsToSpent);

            return transaction.ToHex();
        }

        private TxIn GetInputFromUtxo(BitcoinSecret secret, BitcoinUtxo utxo, List<BitcoinSecret> privateKeysToSign, List<Coin> coinsToSpent)
        {
            uint256 transactionId = uint256.Parse(utxo.Hash);
            var outpoint = new OutPoint(transactionId, (uint)utxo.Index);

            privateKeysToSign.Add(secret);
            var scriptSig = secret.GetAddress(ScriptPubKeyType.Legacy).ScriptPubKey;

            var coinToSpent = new Coin(transactionId, (uint)utxo.Index, Money.Satoshis(utxo.Value), scriptSig);
            coinsToSpent.Add(coinToSpent);

            return new TxIn(outpoint, scriptSig);
        }
    }
}
