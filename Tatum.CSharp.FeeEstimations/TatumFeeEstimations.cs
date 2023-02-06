using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Tatum.CSharp.Core;
using Tatum.CSharp.Core.Models;
using Tatum.CSharp.FeeEstimations.Mappers;
using Tatum.CSharp.FeeEstimations.Models;
using Tatum.CSharp.FeeEstimations.Models.Requests;
using Tatum.CSharp.FeeEstimations.Models.Responses;

namespace Tatum.CSharp.FeeEstimations
{
    public class TatumFeeEstimations : ITatumFeeEstimations
    {
        private const string FeeEstimationsUrl = "/v3/blockchain";

        private readonly HttpClient _httpClient;

        public TatumFeeEstimations(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CurrentFee> GetCurrentFee(Chain chain)
        {
            var currentFeeResponse = await _httpClient.GetFromJsonAsync<CurrentFeeResponse>($"{FeeEstimationsUrl}/fee/{chain}", TatumSerializerOptions.Default);

            return FeeMapper.Map(currentFeeResponse);
        }

        public async Task<EstimatedFee> EstimateFeeForBlockchainTransaction(TransactionDataForFeeEstimation transactionDataForFeeEstimation)
        {
            var result = await _httpClient.PostAsJsonAsync($"{FeeEstimationsUrl}/estimate", transactionDataForFeeEstimation, TatumSerializerOptions.Default);
            
            var estimatedFeeResponse = await result.Content.ReadFromJsonAsync<EstimatedFeeResponse>();
            
            return FeeMapper.Map(estimatedFeeResponse);
        }
    }
}