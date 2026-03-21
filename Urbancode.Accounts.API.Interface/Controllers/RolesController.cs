using Microsoft.AspNetCore.Mvc;
using Urbancode.Accounts.API.Interface.Requests;

namespace Urbancode.Accounts.API.Interface.Controllers;

[ApiController]
[Route("roles")]
public class RolesController : ControllerBase
{
    private readonly ILogger<RolesController> _logger;
    
    public RolesController(ILogger<RolesController> logger)
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

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
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
    public async Task<IActionResult> Post([FromBody] RoleCreateRequest request)
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

    [HttpPost("{id}")]
    public async Task<IActionResult> Post(Guid id, [FromBody] RoleUpdateRequest request)
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

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
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