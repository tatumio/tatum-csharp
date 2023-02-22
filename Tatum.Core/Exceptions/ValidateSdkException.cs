using System;

namespace Tatum.Core.Exceptions
{
    public class ValidateSdkException : Exception
    {
        public ValidateSdkException(string message) : base(message)
        {
        }
    }
}