namespace Tatum.CSharp.Core
{
    public struct Result<T>
    {
        public T Value { get; }
        public string Message { get; }
        public bool Success { get; }

        public Result(T value)
        {
            Value = value;
            Success = true;
            Message = null;
        }
        
        public Result(string message)
        {
            Message = message;
            Success = false;
            Value = default;
        }
    }
}