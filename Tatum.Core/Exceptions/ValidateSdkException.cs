using System;

namespace Tatum.Core.Exceptions
{
    public class ValidateSdkException : Exception
    {
        public ValidateSdkException(string message) : base(message)
        {
        }
        
        public ValidateSdkException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}