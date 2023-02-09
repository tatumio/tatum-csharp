using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Tatum.CSharp.Core;
using Tatum.CSharp.Core.Models;
using Tatum.CSharp.Fees.Mappers;
using Tatum.CSharp.Fees.Models;
using Tatum.CSharp.Fees.Models.Requests;
using Tatum.CSharp.Fees.Models.Responses;

namespace Tatum.CSharp.Fees
{
    public class TatumFees : ITatumFees
    {
        private const string FeeEstimationsUrl = "/v3/blockchain";

        private readonly HttpClient _httpClient;

        public TatumFees(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Dictionary<Chain, ChainCurrentFee>> GetCurrent(IEnumerable<Chain> chains)
        {
            var currentFees = new Dictionary<Chain, ChainCurrentFee>();
            
            foreach (var chain in chains)
            {
                var currentFeeResponse = await _httpClient.GetFromJsonAsync<CurrentFeeResponse>($"{FeeEstimationsUrl}/fee/{ChainMapper.GetChainAbbreviation(chain)}", TatumSerializerOptions.Default);

                if (!currentFees.ContainsKey(chain))
                {
                    currentFees.Add(chain, FeeMapper.Map(currentFeeResponse));
                }
            }

            return currentFees;
        }

        public async Task<ChainCurrentFee> GetCurrent(Chain chain)
        {
            var currentFees = await GetCurrent(new[] { chain });

            currentFees.TryGetValue(chain, out var currentFee);
            
            return currentFee;
        }

        public async Task<NativeTransferFeeEstimation> Estimate(IEnumerable<NativeTransferFeeEstimationDetails> nativeTransferFeeEstimationDetails)
        {
            var nativeTransferFeeEstimation = new NativeTransferFeeEstimation();
            var chainEstimationRequests = new Dictionary<Chain, List<FeeEstimationDetails>>();

            foreach (var nativeTransferFeeEstimationDetail in nativeTransferFeeEstimationDetails)
            {
                if (!chainEstimationRequests.ContainsKey(nativeTransferFeeEstimationDetail.Chain))
                {
                    chainEstimationRequests.Add(nativeTransferFeeEstimationDetail.Chain, new List<FeeEstimationDetails>());
                }
                
                chainEstimationRequests[nativeTransferFeeEstimationDetail.Chain].Add(FeeMapper.Map(nativeTransferFeeEstimationDetail));
            }
            
            foreach (var chainEstimationRequest in chainEstimationRequests)
            {
                switch (chainEstimationRequest.Key)
                {
                    case Chain.Ethereum:
                        var estimationsRequest = new EstimationsRequest
                        {
                            Estimations = chainEstimationRequest.Value
                        };
                        
                        var result = await _httpClient.PostAsJsonAsync("/v3/ethereum/gas/batch", estimationsRequest, TatumSerializerOptions.Default);
            
                        var estimatedFeeResponse = await result.Content.ReadFromJsonAsync<EstimatedFeeResponse>();
                        
                        if (!nativeTransferFeeEstimation.ChainNativeTransferFeeEstimations.ContainsKey(chainEstimationRequest.Key))
                        {
                            nativeTransferFeeEstimation.ChainNativeTransferFeeEstimations.Add(chainEstimationRequest.Key, new List<ChainNativeTransferFeeEstimation>());
                        }
                        
                        nativeTransferFeeEstimation.ChainNativeTransferFeeEstimations[chainEstimationRequest.Key].AddRange(FeeMapper.Map(estimatedFeeResponse));
                        
                        break;
                }
            }
            
            return nativeTransferFeeEstimation;
        }

        public async Task<NativeTransferFeeEstimation> Estimate(NativeTransferFeeEstimationDetails nativeTransferFeeEstimationDetails)
        {
            return await Estimate(new[] { nativeTransferFeeEstimationDetails });
        }
    }
}