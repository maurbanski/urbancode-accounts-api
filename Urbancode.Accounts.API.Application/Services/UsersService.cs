using Urbancode.Accounts.API.Domain;
using Urbancode.Accounts.API.Domain.ErrorHandling;
using Urbancode.Accounts.API.Logic.DTOs;
using Urbancode.Accounts.API.Logic.Interfaces;

namespace Urbancode.Accounts.API.Logic.Services;

public class UsersService
{
    private readonly IUsersRepository _usersRepository;
     
    public UsersService(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }

    public async Task<Result<IList<User>>> GetUsers()
    {
        var users = await _usersRepository.GetUsers();
        return new(users);
    }

    public async Task<Result<User>> GetUser(Guid id)
    {
        var user = await _usersRepository.GetUser(id);
        if (user == null) return CommonErrors.UserNotFoundError(id);

        return user;
    }

    public async Task<Result<User>> GetUser(string email)
    {
        var user = await _usersRepository.GetUser(email);
        if (user == null) return CommonErrors.UserNotFoundError(email);

        return user;
    }

    public async Task<Result> CreateUser(UserCreateDTO dto)
    {
        var userWithThisEmail = await _usersRepository.GetUser(dto.Email);
        if (userWithThisEmail != null) return CommonErrors.UserAlreadyExistsError(dto.Email);
        
        var user = new User
        {
            Name = dto.Name,
            Email = dto.Email,
            Active = true,
            DateCreated = DateTime.UtcNow
        };

        await _usersRepository.CreateUser(user);
        return Result.Success();
    }

    public async Task<Result> UpdateUser(UserUpdateDTO dto)
    {
        var existingUser = await _usersRepository.GetUser(dto.Id);
        if (existingUser == null) return CommonErrors.UserNotFoundError(dto.Id);

        if (dto.Email != existingUser.Email)
        {
            var userWithThisEmail = await _usersRepository.GetUser(dto.Email);
            if (userWithThisEmail != null) return CommonErrors.UserAlreadyExistsError(dto.Email);
        }
        
        var user = new User
        {
            Id = dto.Id,
            Name = dto.Name,
            Active = dto.Active
        };

        await _usersRepository.UpdateUser(user);
        return Result.Success();
    }

    public async Task<Result> DeleteUser(Guid id)
    {
        var existingUser = await _usersRepository.GetUser(id);
        if (existingUser == null) return CommonErrors.UserNotFoundError(id);

        await _usersRepository.DeleteUser(id);
        return Result.Success();
    }
}