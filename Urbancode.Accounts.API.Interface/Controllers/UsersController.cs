using Microsoft.AspNetCore.Mvc;
using Urbancode.Accounts.API.Interface.Requests;
using Urbancode.Accounts.API.Logic.DTOs;
using Urbancode.Accounts.API.Logic.Services;

namespace Urbancode.Accounts.API.Interface.Controllers;

[ApiController]
[Route("users")]
public class UsersController : ApiControllerBase
{
    private readonly ILogger<UsersController> _logger;
    private readonly UsersService _usersService;
    
    public UsersController(ILogger<UsersController> logger, UsersService usersService)
    {
        _logger = logger;
        _usersService = usersService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var usersResult = await _usersService.GetUsers();
            if (usersResult.IsSuccess) return Ok(usersResult.Value);
            else return base.HandleError(usersResult.Error);
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
            var userResult = await _usersService.GetUser(id);
            if (userResult.IsSuccess) return Ok(userResult.Value);
            else return base.HandleError(userResult.Error);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return StatusCode(500);
        }
    }

    [HttpGet("{email}")]
    public async Task<IActionResult> Get(string email)
    {
        try
        {
            var userResult = await _usersService.GetUser(email);
            if (userResult.IsSuccess) return Ok(userResult.Value);
            else return base.HandleError(userResult.Error);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return StatusCode(500);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] UserCreateRequest request)
    {
        try
        {
            var dto = new UserCreateDTO()
            {
                Id = request.Id,
                Email = request.Email,
                Name = request.Name
            };

            var result = await _usersService.CreateUser(dto);
            if (result.IsSuccess) return Ok();
            else return base.HandleError(result.Error);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return StatusCode(500);
        }
    }

    [HttpPost("{id}")]
    public async Task<IActionResult> Post(Guid id, [FromBody] UserUpdateRequest request)
    {
        try
        {
            var dto = new UserUpdateDTO()
            {
                Id = id,
                Email = request.Email,
                Name = request.Name,
                Active = request.Active
            };

            var result = await _usersService.UpdateUser(dto);
            if (result.IsSuccess) return Ok();
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
            var userResult = await _usersService.DeleteUser(id);
            if (userResult.IsSuccess) return Ok();
            else return base.HandleError(userResult.Error);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return StatusCode(500);
        }
    }
}