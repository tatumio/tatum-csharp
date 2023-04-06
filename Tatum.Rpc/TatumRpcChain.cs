using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using Tatum.Core;
using Tatum.Core.Configuration;
using Tatum.Core.Extensions;
using Tatum.Core.Serialization;
using Tatum.Rpc.Comparers;
using Tatum.Rpc.Constants;
using Tatum.Rpc.Exceptions;
using Tatum.Rpc.Models;

namespace Tatum.Rpc
{
    public sealed class TatumRpcChain : TatumClientBase, ITatumRpcChain, IDisposable
    {
        private readonly IRpcConfiguration _configuration;
        private readonly IBlockchainConfig _chainConfiguration;
        private readonly RpcChain _chain;
        private readonly SortedSet<Node> _nodes = new SortedSet<Node>(new NodeComparer());
        private Node _activeNode;
        private bool _initialised;
        private Timer _configUpdateTimer;

        private readonly TimeSpan _configUpdateInterval = TimeSpan.FromMinutes(1);

        internal TatumRpcChain(RpcChain chain, HttpClient httpClient, ITatumSdkConfiguration configuration) : base(
            httpClient, configuration)
        {
            _configuration = configuration.Rpc;
            _chainConfiguration = GetChainConfiguration(chain);
            _chain = chain;
        }

        internal TatumRpcChain(RpcChain chain, IHttpClientFactory httpClientFactory, ITatumSdkConfiguration configuration)
            : base(httpClientFactory, configuration)
        {
            _configuration = configuration.Rpc;
            _chainConfiguration = GetChainConfiguration(chain);
            _chain = chain;
        }
        
        private IBlockchainConfig GetChainConfiguration(RpcChain chain)
        {
            return chain switch
            {
                RpcChain.Bitcoin => _configuration.Bitcoin,
                RpcChain.Litecoin => _configuration.Litecoin,
                RpcChain.Polygon => _configuration.Polygon,
                RpcChain.Ethereum => _configuration.Ethereum,
                RpcChain.Monero => _configuration.Monero,
                _ => throw new ArgumentOutOfRangeException(nameof(chain), chain, null)
            };
        }

        public async Task<Result<object>> Call(JsonRpcCall request)
        {
            if (!_initialised)
            {
                await InitialiseInternal();
                _initialised = true;
            }

            try
            {
                var responseMessage = await GetClient()
                    .PostAsJsonAsync(_activeNode.Url, request, TatumSerializerOptions.Default)
                    .ConfigureAwait(false);
                
                return await responseMessage.ToResultAsync<object>().ConfigureAwait(false);
            }
            catch
            {
                if (_nodes.Count == 0) 
                    throw;

                _nodes.Remove(_activeNode);
                
                if (_nodes.Count == 0)
                    throw new TatumOpenRpcException($"All nodes for {_chain} are down");

                _activeNode = _nodes.Min;
                
                return await Call(request);
            }
        }

        private async Task InitialiseInternal()
        {
            if (_chainConfiguration.Url.Any())
            {
                _activeNode = new Node()
                {
                    Url = _chainConfiguration.Url.First()
                };
                
                return;
            }
            
            if (_configuration.WaitForFastestNode)
            {
                await UpdateNodes();
            }
            else
            {
                await InitNodes();
            }


            if (!_configuration.IgnoreLoadBalancing)
            {
                StartConfigUpdateTimer();
            }
        }

        private async Task UpdateNodes()
        {
            var httpResponseMessage = await GetClient().GetAsync(RpcConstants.ConfigUrls[_chain]).ConfigureAwait(false);

            var nodes = await httpResponseMessage.Content.ReadFromJsonAsync<List<Node>>(TatumSerializerOptions.Default)
                .ConfigureAwait(false);

            _nodes.Clear();
            
            foreach (var node in nodes ?? new List<Node>())
            {
                try
                {
                    var getBlockCountCall = new JsonRpcCall
                    {
                        Id = "1",
                        JsonRpc = "2.0",
                        Method = "getblockcount"
                    };

                    var client = GetClient();

                    var stopwatch = Stopwatch.StartNew();


                    var response = await client
                        .PostAsJsonAsync(node.Url, getBlockCountCall, TatumSerializerOptions.Default)
                        .ConfigureAwait(false);

                    stopwatch.Stop();

                    node.ResponseTime = stopwatch.ElapsedMilliseconds;

                    var result = await response.ToResultAsync<StatusResponse>().ConfigureAwait(false);

                    node.BlockCount = result.Value.Result;

                    _nodes.Add(node);
                }
                catch
                {
                    // ignored
                }
            }

            // remove nodes that are too far behind
            foreach (var node in _nodes)
            {
                if(_activeNode.BlockCount - node.BlockCount > _configuration.AllowedBlocksBehind)
                {
                    _nodes.Remove(node);
                }
            }
            
            _activeNode = _nodes.Min;
            
            if (_configuration.OneTimeLoadBalancing)
            {
                _configUpdateTimer.Dispose();
                _configUpdateTimer = null;
            }
        }

        private async Task InitNodes()
        {
            var httpResponseMessage = await GetClient().GetAsync(RpcConstants.ConfigUrls[_chain]).ConfigureAwait(false);

            var nodes = await httpResponseMessage.Content.ReadFromJsonAsync<List<Node>>(TatumSerializerOptions.Default)
                .ConfigureAwait(false);

            _activeNode = nodes?[new Random().Next(0, nodes.Count)];
        }

        private async void UpdateNodesHeartbeat(object state) => await UpdateNodes();

        private void StartConfigUpdateTimer() =>
            _configUpdateTimer = new Timer(UpdateNodesHeartbeat, null, _configUpdateInterval, _configUpdateInterval);

        public void Dispose()
        {
            _configUpdateTimer?.Dispose();
        }
    }
}