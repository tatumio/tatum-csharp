﻿using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Tatum.Blockchain;
using Tatum.Model.Requests;
using Tatum.Model.Responses;

namespace Tatum.Clients
{
    public partial class VeChainClient : IVeChainClient
    {
        private readonly IVeChainApi veChainApi;

        internal VeChainClient()
        {
        }

        internal VeChainClient(string apiBaseUrl, string xApiKey)
        {
            veChainApi = RestClientFactory.Create<IVeChainApi>(apiBaseUrl, xApiKey);
        }

        public static IVeChainClient Create(string apiBaseUrl, string xApiKey)
        {
            return new VeChainClient(apiBaseUrl, xApiKey);
        }

        Task<TransactionHash> IVeChainClient.Broadcast(BroadcastRequest request)
        {
            var validationContext = new ValidationContext(request);
            Validator.ValidateObject(request, validationContext, validateAllProperties: true);

            return veChainApi.Broadcast(request);
        }

        Task<long> IVeChainClient.EstimateGas(EstimateGasRequest request)
        {
            var validationContext = new ValidationContext(request);
            Validator.ValidateObject(request, validationContext, validateAllProperties: true);

            return veChainApi.EstimateGas(request);
        }

        Task<VeChainAccountBalance> IVeChainClient.GetAccountBalance(string address)
        {
            return veChainApi.GetAccountBalance(address);
        }

        Task<VeChainAccountEnergy> IVeChainClient.GetAccountEnergy(string address)
        {
            return veChainApi.GetAccountEnergy(address);
        }

        Task<VeChainBlock> IVeChainClient.GetBlock(string hash)
        {
            return veChainApi.GetBlock(hash);
        }

        Task<long> IVeChainClient.GetCurrentBlock()
        {
            return veChainApi.GetCurrentBlock();
        }

        Task<VeChainTx> IVeChainClient.GetTransaction(string hash)
        {
            return veChainApi.GetTransaction(hash);
        }

        Task<VeChainTxReceipt> IVeChainClient.GetTransactionReceipt(string hash)
        {
            return veChainApi.GetTransactionReceipt(hash);
        }
    }
}
