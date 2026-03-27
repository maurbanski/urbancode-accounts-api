using Microsoft.AspNetCore.Mvc;
using Urbancode.Accounts.API.Logic.Services;

namespace Urbancode.Accounts.API.Interface.Controllers;

[ApiController]
[Route("roles/{id:guid}/members")]
public class RoleMembersController : ApiControllerBase
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
        try
        {
            var membersResult = await _roleMembersService.GetRoleMembers(id);
            if (membersResult.IsSuccess) return Ok(membersResult.Value);
            else return base.HandleError(membersResult.Error);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return StatusCode(500);
        }
    }

    [HttpGet("count")]
    public async Task<IActionResult> Count(Guid id)
    {
        try
        {
            var membersResult = await _roleMembersService.GetRoleMembers(id);
            if (membersResult.IsSuccess) return Ok(membersResult.Value.Count);
            else return base.HandleError(membersResult.Error);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return StatusCode(500);
        }
    }
    
    [HttpPost]
    public async Task<IActionResult> Post(Guid id, Guid userId)
    {
        try
        {
            var result = await _roleMembersService.AddRoleMember(id, userId);
            if (result.IsSuccess) return Ok(result);
            else return base.HandleError(result.Error);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return StatusCode(500);
        }
    }
    
    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id, Guid userId)
    {
        try
        {
            var result = await _roleMembersService.RemoveRoleMember(id, userId);
            if (result.IsSuccess) return Ok(result);
            else return base.HandleError(result.Error);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return StatusCode(500);
        }
    }
}