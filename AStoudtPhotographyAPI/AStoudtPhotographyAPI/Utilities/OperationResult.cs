namespace AStoudtPhotographyAPI.Utilities
{
    public class OperationResult<T>
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }
        public List<string> Errors { get; set; }

        public OperationResult()
        {
            Errors = new List<string>();
        }

        public static OperationResult<T> SuccessResult(T? data, string message = "")
        {
            return new OperationResult<T>
            {
                Success = true,
                Data = data,
                Message = message
            };
        }

        public static OperationResult<T> FailureResult(string message, List<string>? errors = null)
        {
            return new OperationResult<T>
            {
                Success = false,
                Message = message,
                Errors = errors ?? new List<string>()
            };
        }
    }
}
