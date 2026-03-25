using Microsoft.AspNetCore.Mvc;
using Urbancode.Accounts.API.Logic.Services;

namespace Urbancode.Accounts.API.Interface.Controllers;

[ApiController]
[Route("roles/{id}/members")]
public class RoleMembersController : ControllerBase
{
    private readonly ILogger<RoleMembersController> _logger;
    private readonly RoleMembersService _roleMembersService;
    
    public RoleMembersController(ILogger<RoleMembersController> logger, RoleMembersService roleMembersService)
    {
        _logger = logger;
        _roleMembersService = roleMembersService;
    }

    [HttpGet]
    public async Task<IActionResult> Get(Guid id)
    {
        var a = _roleMembersService.GetRoleMembers().
    }

    [HttpGet("count")]
    public async Task<IActionResult> Count(Guid id)
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
    public async Task<IActionResult> Post(Guid id)
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