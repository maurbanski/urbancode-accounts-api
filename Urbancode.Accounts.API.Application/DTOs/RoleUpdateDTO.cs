namespace Urbancode.Accounts.API.Logic.DTOs;

public record RoleUpdateDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool Active { get; set; }
}