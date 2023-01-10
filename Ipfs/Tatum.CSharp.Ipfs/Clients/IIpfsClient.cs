using Tatum.CSharp.Ipfs.Core.Api;

namespace Tatum.CSharp.Ipfs.Clients
{
    public interface IIpfsClient
    {
        /// <summary>
        /// Client wrapping all operations related to the Ipfs.
        /// </summary>
        IIpfsApiAsync Ipfs { get; }
        
        /// <summary>
        /// Client wrapping all operations related to the Ipfs with full <see cref="ApiResponse{T}"/> return types.
        /// </summary>
        IIpfsApiWithHttpInfoAsync IpfsWithHttpInfo { get; }
    }
}