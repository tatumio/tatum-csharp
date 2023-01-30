using Tatum.CSharp.Ipfs.Core.Api;

namespace Tatum.CSharp.Ipfs.Clients
{
    public interface IIpfsClient
    {
        /// <summary>
        /// Client wrapping all operations related to the IPFS.
        /// </summary>
        IIPFSApiAsync Ipfs { get; }
        
        /// <summary>
        /// Client wrapping all operations related to the IPFS with full <see cref="ApiResponse{T}"/> return types.
        /// </summary>
        IIPFSApiWithHttpInfoAsync IpfsWithHttpInfo { get; }
    }
}