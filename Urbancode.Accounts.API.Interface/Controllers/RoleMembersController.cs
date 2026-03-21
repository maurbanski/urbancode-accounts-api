using Microsoft.AspNetCore.Mvc;

namespace Urbancode.Accounts.API.Interface.Controllers;

[ApiController]
[Route("roles/{id}/members")]
public class RoleMembersController : ControllerBase
{
    private readonly ILogger<RoleMembersController> _logger;
    
    public RoleMembersController(ILogger<RoleMembersController> logger)
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

    [HttpGet("count")]
    public async Task<IActionResult> Count()
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
    
    [HttpPost]
    public async Task<IActionResult> Post()
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
    
    [HttpDelete]
    public async Task<IActionResult> Delete()
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