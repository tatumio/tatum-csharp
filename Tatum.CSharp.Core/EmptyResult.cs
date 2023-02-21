namespace Tatum.CSharp.Core
{
    public class EmptyResult
    {
        public string ErrorMessage { get; }
        public bool Success { get; }

        public EmptyResult()
        {
            Success = true;
            ErrorMessage = null;
        }
        
        public EmptyResult(string errorMessage)
        {
            ErrorMessage = errorMessage;
            Success = false;
        }
    }
}