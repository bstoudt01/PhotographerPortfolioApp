namespace AStoudtPhotographyAPI.Utilities
{
    public class ValidatedResult
    {
        public bool Success { get; set; }
        public List<string> Errors { get; set; }
        public string Message { get; set; } = string.Empty;

        public ValidatedResult()
        {
            Errors = new List<string>();
        }

        public static ValidatedResult SuccessResult(string message = "")
        {
            return new ValidatedResult
            {
                Success = true,
                Message = message
            };
        }

        public static ValidatedResult FailureResult(string message, List<string>? errors = null)
        {
            return new ValidatedResult
            {
                Success = false,
                Message = message,
                Errors = errors ?? new List<string>()
            };
        }
    }
}
