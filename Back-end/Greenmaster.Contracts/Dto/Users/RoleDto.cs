namespace Greenmaster.Contracts.Dto.Users;

public class RoleDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public ICollection<string> Permissions { get; set; } = new List<string>();
}