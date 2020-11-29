using NBitcoin;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Tatum.Blockchain;
using Tatum.Model.Requests;
using Tatum.Model.Responses;

namespace Tatum.Clients
{
    public partial class LitecoinClient : ILitecoinClient
    {
        Task<string> ILitecoinClient.SignKmsTransaction(TransactionKms tx, List<string> privateKeys, bool testnet)
        {
            throw new NotImplementedException();
        }

        Task<string> ILitecoinClient.PrepareSignedTransaction(TransferBtcBasedBlockchain body, bool testnet)
        {
            return PrepareSignedTransaction(testnet ? LitecoinTatum.Instance.Testnet : LitecoinTatum.Instance.Mainnet, body);
        }

        async Task<TransactionHash> ILitecoinClient.SendTransaction(TransferBtcBasedBlockchain body, bool testnet)
        {
            string txData = await (this as ILitecoinClient).PrepareSignedTransaction(body, testnet).ConfigureAwait(false);
            var broadcastRequest = new BroadcastRequest
            {
                TxData = txData
            };

            return await (this as ILitecoinClient).BroadcastSignedTransaction(broadcastRequest).ConfigureAwait(false);
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
                    List<LitecoinTx> inputTxes = await (this as ILitecoinClient).GetTxForAccount(fromAddress.Address).ConfigureAwait(false);
                    foreach (LitecoinTx inputTx in inputTxes)
                    {
                        for (int i = 0; i < inputTx.Outputs.Count; i++)
                        {
                            if (inputTx.Outputs[i].Address == fromAddress.Address)
                            {
                                var secret = new BitcoinSecret(fromAddress.PrivateKey, network);
                                try
                                {
                                    LitecoinUtxo utxo = await (this as ILitecoinClient).GetUtxo(inputTx.Hash, i).ConfigureAwait(false);

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
                        LitecoinUtxo utxo = await (this as ILitecoinClient).GetUtxo(fromUtxo.TxHash, (int)fromUtxo.Index).ConfigureAwait(false);

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

        private TxIn GetInputFromUtxo(BitcoinSecret secret, LitecoinUtxo utxo, List<BitcoinSecret> privateKeysToSign, List<Coin> coinsToSpent)
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
