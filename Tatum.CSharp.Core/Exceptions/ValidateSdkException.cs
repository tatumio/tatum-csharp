using System;

namespace Tatum.CSharp.Core.Exceptions
{
    public class ValidateSdkException : Exception
    {
        public ValidateSdkException(string message) : base(message)
        {
        }
    }
}