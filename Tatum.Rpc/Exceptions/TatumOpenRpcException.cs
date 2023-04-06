using System;

namespace Tatum.Rpc.Exceptions
{
    public class TatumOpenRpcException : Exception
    {
        public TatumOpenRpcException(string s) : base(s)
        {
        }
        
        public TatumOpenRpcException(string s, Exception e) : base(s, e)
        {
        }
    }
}