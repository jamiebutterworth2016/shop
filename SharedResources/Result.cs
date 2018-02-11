namespace SharedResources
{
    public class Result<T>
    {
        public bool Success { get; private set; }
        public T Value { get; private set; }
        public string Error { get; private set; }

        public Result(T value)
        {
            Success = true;
            Value = value;
        }

        public Result(string error)
        {
            Success = false;
            Error = error;
        }
    }

    public class Result
    {
        public bool Success { get; private set; }
        public string Error { get; private set; }

        public Result()
        {
            Success = true;
        }

        public Result(string error)
        {
            Success = false;
            Error = error;
        }
    }
}