namespace Tatum.CSharp.Core
{
    public struct Result<T>
    {
        public T Value { get; }
        public string ErrorMessage { get; }
        public bool Success { get; }

        public Result(T value)
        {
            Value = value;
            Success = true;
            ErrorMessage = null;
        }
        
        public Result(string errorMessage)
        {
            ErrorMessage = errorMessage;
            Success = false;
            Value = default;
        }
        public static implicit operator Result<T>(T value) => new Result<T>(value);
    }
}