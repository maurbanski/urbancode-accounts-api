using Microsoft.AspNetCore.Mvc;
using Urbancode.Accounts.API.Interface.Requests;

namespace Urbancode.Accounts.API.Interface.Controllers;

[ApiController]
[Route("users/{id}/roles")]
public class UserRolesController : ControllerBase
{
    private readonly ILogger<UserRolesController> _logger;
    
    public UserRolesController(ILogger<UserRolesController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            throw new NotImplementedException();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return BadRequest();
        }
    }
}