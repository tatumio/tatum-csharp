using NBitcoin;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Tatum.Model.Requests;
using Tatum.Model.Responses;

namespace Tatum.Clients
{
    public partial class BitcoinClient : IBitcoinClient
    {
        const int TenMillion = 100000000;

        async Task IBitcoinClient.SendOffchainTransaction(TransferBtcBasedOffchain body, bool testnet)
        {
            var validationContext = new ValidationContext(body);
            Validator.ValidateObject(body, validationContext);

            if (string.IsNullOrWhiteSpace(body.Fee))
            {
                body.Fee = "0.0005";
            }

            var withdrawal = new CreateWithdrawal
            {
                
            };
            await tatumClient.OffchainStoreWithdrawal(withdrawal);
            throw new NotImplementedException();
        }

        string IBitcoinClient.PrepareSignedOffchainTransaction(List<WithdrawalResponseData> data, string amount, string address, bool testnet, string mnemonic,
            List<KeyPair> keyPairs, string changeAddress, List<string> multipleAmounts)
        {
            Network network = testnet ? Network.TestNet : Network.Main;
            NBitcoin.Transaction transaction = network.CreateTransaction();

            foreach (WithdrawalResponseData input in data)
            {
                var validationContext = new ValidationContext(input);
                Validator.ValidateObject(input, validationContext);

                if (input.VIn != "-1")
                {
                    var txInput = new TxIn(new OutPoint(uint256.Parse(input.VIn), (uint)input.VInIndex));
                    transaction.Inputs.Add(txInput);
                }
            }

            WithdrawalResponseData lastVin = data.FirstOrDefault(d => d.VIn == "-1");

            if (multipleAmounts != null && multipleAmounts.Count > 0)
            {
                var addresses = address.Split(',');
                for (int i = 0; i < multipleAmounts.Count; i++)
                {
                    long satoshis = (long)(double.Parse(multipleAmounts[i]) * TenMillion);
                    var outputAddress = BitcoinAddress.Create(addresses[i], network);
                    transaction.Outputs.Add(new Money(satoshis), outputAddress);
                }
            }
            else
            {
                long satoshis = (long)(double.Parse(amount) * TenMillion);
                transaction.Outputs.Add(new Money(satoshis), BitcoinAddress.Create(address, network));
            }

            if (!string.IsNullOrWhiteSpace(mnemonic) && string.IsNullOrWhiteSpace(changeAddress))
            {
                Wallet wallet = (this as IBitcoinClient).CreateWallet(mnemonic, testnet);

                var outputAddress = (this as IBitcoinClient).GenerateAddress(wallet.XPub, 0, testnet);
                long satoshis = (long)(lastVin.Amount * TenMillion);

                transaction.Outputs.Add(new Money(satoshis), BitcoinAddress.Create(outputAddress, network));
            }
            else if (!string.IsNullOrWhiteSpace(changeAddress))
            {
                long satoshis = (long)(lastVin.Amount * TenMillion);
                var outputAddress = BitcoinAddress.Create(changeAddress, network);
                transaction.Outputs.Add(new Money(satoshis), outputAddress);
            }
            else
            {
                throw new ValidationException("Impossible to prepare transaction. Either mnemonic or keyPair and attr must be present.");
            }

            for (int i = 0; i < data.Count; i++)
            {
                if (data[i].VIn == "-1")
                {
                    continue;
                }

                if (!string.IsNullOrWhiteSpace(mnemonic))
                {
                    var derivationKey = data[i].Address?.DerivationKey ?? 0;
                    var privateKey = (this as IBitcoinClient).GeneratePrivateKey(mnemonic, (int)derivationKey, testnet);
                    transaction.Sign(new BitcoinSecret(privateKey), new Coin(transaction, transaction.Outputs[i]));
                }
                else if (keyPairs != null)
                {
                    KeyPair keyPair = keyPairs.FirstOrDefault(kp => kp.Address == data[i].Address.BlockchainAddress);
                    transaction.Sign(new BitcoinSecret(keyPair.PrivateKey), new Coin(transaction, transaction.Outputs[i]));
                }
                else
                {
                    throw new ValidationException("Impossible to prepare transaction. Either mnemonic or keyPair and attr must be present.");
                }
            }

            return transaction.ToHex();
        }
    }
}
