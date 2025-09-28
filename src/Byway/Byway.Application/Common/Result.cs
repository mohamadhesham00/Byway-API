namespace Byway.Application.Common
{
    public class Result<T>
    {
        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public string? ErrorMessage { get; }
        public int? Status { get; }
        public T? Value { get; }

        protected Result(bool isSuccess, T? value, string? error, int? status)
        {
            IsSuccess = isSuccess;
            Value = value;
            Status = status;
            ErrorMessage = error;
        }

        public static Result<T> Success(T value) =>
            new Result<T>(true, value, null, 200);

        public static Result<T> Failure(string error, int status) =>
            new Result<T>(false, default, error, status);
    }

    // Non-generic version for operations that don't return a value
    public class Result
    {
        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public string? Error { get; }

        protected Result(bool isSuccess, string? error)
        {
            IsSuccess = isSuccess;
            Error = error;
        }

        public static Result Success() => new Result(true, null);
        public static Result Failure(string error) => new Result(false, error);
    }
}
