using System.Net;

namespace AuhtServer.Shared.Results;

public class Result<T> where T : class
{
    public T? Data { get; set; }
    public List<string>? ErrorMessages { get; set; }
    public bool IsSuccess => ErrorMessages is null || ErrorMessages.Count == 0;
    public bool IsFail => !IsSuccess;
    public HttpStatusCode StatusCode { get; set; }

    public static Result<T> Success(T data, HttpStatusCode statusCode = HttpStatusCode.OK) => new Result<T> { Data = data, StatusCode = statusCode };
    public static Result<T> Fail(List<string> errorMessage, HttpStatusCode statusCode = HttpStatusCode.BadRequest) => new Result<T> { ErrorMessages = errorMessage, StatusCode = statusCode };
    public static Result<T> Fail(string errorMessage, HttpStatusCode statusCode = HttpStatusCode.BadRequest) => new Result<T> { ErrorMessages =  [errorMessage], StatusCode = statusCode  };
}

public class Result
{
    public List<string>? ErrorMessages { get; set; }
    public bool IsSuccess => ErrorMessages is null || ErrorMessages.Count == 0;
    public bool IsFail => !IsSuccess;
    public HttpStatusCode StatusCode { get; set; }

    public static Result Success(HttpStatusCode statusCode = HttpStatusCode.OK) => new Result { StatusCode = statusCode };
    public static Result Fail(List<string> errorMessages, HttpStatusCode statusCode = HttpStatusCode.BadRequest) => new Result { ErrorMessages = errorMessages, StatusCode = statusCode };
    public static Result Fail(string errorMessage, HttpStatusCode statusCode = HttpStatusCode.BadRequest) => new Result { ErrorMessages = [errorMessage], StatusCode = statusCode };
}
