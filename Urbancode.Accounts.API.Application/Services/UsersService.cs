using Urbancode.Accounts.API.Domain;
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

    public async Task<IList<User>> GetUsers()
    {
        return await _usersRepository.GetUsers();
    }

    public async Task<User> GetUser(Guid id)
    {
        var user = await _usersRepository.GetUser(id);
        if (user == null) throw new ArgumentException($"User with this Id not found (Id: {id})");

        return user;
    }

    public async Task<User> GetUser(string email)
    {
        var user = await _usersRepository.GetUser(email);
        if (user == null) throw new ArgumentException($"User with this email not found (Email: {email})");

        return user;
    }

    public async Task CreateUser(UserCreateDTO dto)
    {
        var userWithThisEmail = await GetUser(dto.Email);
        if (userWithThisEmail != null) throw new ArgumentException($"User with this email already exists (email: {dto.Email})");
        
        var user = new User
        {
            Name = dto.Name,
            Email = dto.Email,
            Active = true,
            DateCreated = DateTime.UtcNow
        };

        await _usersRepository.CreateUser(user);
    }

    public async Task UpdateUser(UserUpdateDTO dto)
    {
        var existingUser = await GetUser(dto.Id);
        if (existingUser == null) throw new ArgumentException($"User with this Id not found (Id: {dto.Id})");

        if (dto.Email != existingUser.Email)
        {
            var userWithThisEmail = await GetUser(dto.Email);
            if (userWithThisEmail != null) throw new ArgumentException($"User with this email already exists (email: {dto.Email})");
        }
        
        var user = new User
        {
            Id = dto.Id,
            Name = dto.Name,
            Active = dto.Active
        };

        await _usersRepository.UpdateUser(user);
    }

    public async Task DeleteUser(Guid id)
    {
        var existingUser = await GetUser(id);
        if (existingUser == null) throw new ArgumentException($"User with this Id not found (Id: {id})");

        await _usersRepository.DeleteUser(id);
    }
}