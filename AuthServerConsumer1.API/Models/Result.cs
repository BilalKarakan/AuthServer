using System.Net;

namespace AuthServerConsumer1.API.Models;

public class Result<T> where T : class
{
    public T? Data { get; set; }
    public List<string>? ErrorMessages { get; set; }
    public bool IsSuccess => this.ErrorMessages is null || this.ErrorMessages.Count == 0;
    public bool IsFail => !this.IsSuccess;
    public HttpStatusCode StatusCode { get; set; }
}
