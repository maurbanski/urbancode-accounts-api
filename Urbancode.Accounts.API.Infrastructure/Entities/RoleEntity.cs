using System.Runtime.CompilerServices;
using Urbancode.Accounts.API.Domain;

namespace Urbancode.Accounts.API.Infrastructure.Entities;

public record RoleEntity
{
    public Guid id { get; set; }
    public string name { get; set; }
    public bool active { get; set; }
    public DateTime date_created { get; set; }

    public RoleEntity(Guid id, string name, bool active, DateTime date_created)
    {
        this.id = id;
        this.name = name;
        this.active = active;
        this.date_created = date_created;
    }

    public RoleEntity(Role role) : this(role.Id, role.Name, role.Active, role.DateCreated) { }

    public Role ToRole()
    {
        return new Role
        {
            Id = id,
            Name = name,
            Active = active,
            DateCreated = date_created
        };
    }
}