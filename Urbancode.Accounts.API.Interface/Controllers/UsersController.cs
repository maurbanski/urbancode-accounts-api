using Microsoft.AspNetCore.Mvc;
using Urbancode.Accounts.API.Interface.Requests;
using Urbancode.Accounts.API.Logic.DTOs;
using Urbancode.Accounts.API.Logic.Services;

namespace Urbancode.Accounts.API.Interface.Controllers;

[ApiController]
[Route("users")]
public class UsersController : ControllerBase
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
            var users = await _usersService.GetUsers();
            return Ok(users);
        }
        catch (ArgumentException ex)
        {
            _logger.LogError(ex, ex.Message);
            return BadRequest();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return StatusCode(500);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        try
        {
            var user = await _usersService.GetUser(id);
            return Ok(user);
        }
        catch (ArgumentException ex)
        {
            _logger.LogError(ex, ex.Message);
            return BadRequest();
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
            var user = await _usersService.GetUser(email);
            return Ok(user);
        }
        catch (ArgumentException ex)
        {
            _logger.LogError(ex, ex.Message);
            return BadRequest();
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
            var userCreateDto = new UserCreateDTO
            {
                Id = request.Id,
                Email = request.Email,
                Name = request.Name
            };

            await _usersService.CreateUser(userCreateDto);
            return Ok();
        }
        catch (ArgumentException ex)
        {
            _logger.LogError(ex, ex.Message);
            return BadRequest();
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
            var userUpdateDto = new UserUpdateDTO()
            {
                Id = id,
                Email = request.Email,
                Name = request.Name,
                Active = request.Active
            };

            await _usersService.UpdateUser(userUpdateDto);
            return Ok();
        }
        catch (ArgumentException ex)
        {
            _logger.LogError(ex, ex.Message);
            return BadRequest();
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
            await _usersService.DeleteUser(id);
            return Ok();
        }
        catch (ArgumentException ex)
        {
            _logger.LogError(ex, ex.Message);
            return BadRequest();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return StatusCode(500);
        }
    }
}