namespace Tatum.CSharp.Core
{
    public class Result<T>
    {
        public T Value { get; }
        public string Message { get; }
        public bool Success { get; }

        public Result(T value)
        {
            Value = value;
            Success = true;
        }
        
        public Result(string message)
        {
            Message = message;
            Success = false;
        }
    }
}