using Microsoft.AspNetCore.Mvc;
using Urbancode.Accounts.API.Interface.Requests;
using Urbancode.Accounts.API.Logic.DTOs;
using Urbancode.Accounts.API.Logic.Services;

namespace Urbancode.Accounts.API.Interface.Controllers;

[ApiController]
[Route("roles")]
public class RolesController : ApiControllerBase
{
    private readonly ILogger<RolesController> _logger;
    private readonly RolesService _rolesService;
    
    public RolesController(ILogger<RolesController> logger, RolesService rolesService)
    {
        _logger = logger;
        _rolesService = rolesService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var rolesResult = await _rolesService.GetRoles();
            if (rolesResult.IsSuccess) return Ok(rolesResult.Value);
            else return base.HandleError(rolesResult.Error);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return StatusCode(500);
        }
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        try
        {
            var roleResult = await _rolesService.GetRole(id);
            if (roleResult.IsSuccess) return Ok(roleResult.Value);
            else return base.HandleError(roleResult.Error);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return StatusCode(500);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] RoleCreateRequest request)
    {
        try
        {
            var dto = new RoleCreateDTO()
            {
                Name = request.Name
            };
            
            var result = await _rolesService.CreateRole(dto);
            if (result.IsSuccess) return Ok(result.Value);
            else return base.HandleError(result.Error);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return StatusCode(500);
        }
    }

    [HttpPost("{id:guid}")]
    public async Task<IActionResult> Post(Guid id, [FromBody] RoleUpdateRequest request)
    {
        try
        {
            var dto = new RoleUpdateDTO()
            {
                Id = id,
                Name = request.Name
            };
            
            var result = await _rolesService.UpdateRole(dto);
            if (result.IsSuccess) return Ok(result);
            else return base.HandleError(result.Error);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return StatusCode(500);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            var result = await _rolesService.DeleteRole(id);
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