using Microsoft.AspNetCore.Mvc;
using Urbancode.Accounts.API.Domain.ErrorHandling;

namespace Urbancode.Accounts.API.Interface.Controllers;

public class ApiControllerBase : ControllerBase
{
    private readonly ILogger _logger;
    
    public ApiControllerBase(ILogger logger)
    {
        _logger = logger;
    }
    
    public IActionResult HandleError(Error error)
    {
        _logger.LogError(error.MessageLong);
        
        return error.Type switch
        {
            ErrorType.NotFound => NotFound(error.MessageShort),
            ErrorType.Conflict => Conflict(error.MessageShort),
            ErrorType.Unauthorised => Forbid(error.MessageShort),
            ErrorType.Validation => BadRequest(error.MessageShort)
        };
    }
}