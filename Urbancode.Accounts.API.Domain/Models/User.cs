namespace Urbancode.Accounts.API.Domain;

public record struct User
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public bool Active { get; set; }
    public DateTime DateCreated { get; set; }
}