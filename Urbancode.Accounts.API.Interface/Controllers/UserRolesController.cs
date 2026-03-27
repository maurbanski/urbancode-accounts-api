using Microsoft.AspNetCore.Mvc;
using Urbancode.Accounts.API.Interface.Requests;
using Urbancode.Accounts.API.Logic.Services;

namespace Urbancode.Accounts.API.Interface.Controllers;

[ApiController]
[Route("users/{id:guid}/roles")]
public class UserRolesController : ApiControllerBase
{
    private readonly ILogger<UserRolesController> _logger;
    private readonly UserRolesService _userRolesService;
    
    public UserRolesController(ILogger<UserRolesController> logger, UserRolesService userRolesService)
    {
        _logger = logger;
        _userRolesService = userRolesService;
    }

    [HttpGet]
    public async Task<IActionResult> Get(Guid id)
    {
        try
        {
            var userRolesResult = await _userRolesService.GetUserRoles(id);
            if (userRolesResult.IsSuccess) return Ok(userRolesResult.Value);
            else return base.HandleError(userRolesResult.Error);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return StatusCode(500);
        }
    }
}