using Urbancode.Accounts.API.Domain;

namespace Urbancode.Accounts.API.Infrastructure.Entities;

public record struct UserEntity
{
    public Guid id { get; set; }
    public string email { get; set; }
    public string name { get; set; }
    public bool active { get; set; }
    public DateTime date_created { get; set; }

    public UserEntity(Guid id, string email, string name, bool active, DateTime date_created)
    {
        this.id = id;
        this.email = email;
        this.name = name;
        this.active = active;
        this.date_created = date_created;
    }

    public UserEntity(User user) : this(user.Id, user.Email, user.Name, user.Active, user.DateCreated) { }
    
    public User ToUser()
    {
        return new User
        {
            Id = id,
            Email = email,
            Name = name,
            Active = active,
            DateCreated = date_created
        };
    }
}