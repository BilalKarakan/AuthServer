using AuhtServer.Shared.Results;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AuthServer.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BaseController : ControllerBase
{
    [NonAction]
    public IActionResult CreateInstance<T>(Result<T> result) where T : class
    {
        return result.StatusCode switch
        {
            HttpStatusCode.Created => Created(string.Empty, result),
            HttpStatusCode.NoContent => NoContent(),
            HttpStatusCode.BadRequest => BadRequest(result),
            HttpStatusCode.Unauthorized => Unauthorized(result),
            HttpStatusCode.NotFound => NotFound(result),
            _ => new ObjectResult(result) { StatusCode = result.StatusCode.GetHashCode() }
        };
    }

    [NonAction]
    public IActionResult CreateInstance(Result result)
    {
        return result.StatusCode switch
        {
            HttpStatusCode.Created => Created(string.Empty, result),
            HttpStatusCode.NoContent => NoContent(),
            HttpStatusCode.BadRequest => BadRequest(result),
            HttpStatusCode.Unauthorized => Unauthorized(result),
            HttpStatusCode.NotFound => NotFound(result),
            _ => new ObjectResult(result) { StatusCode = result.StatusCode.GetHashCode() }
        };
    }
}
