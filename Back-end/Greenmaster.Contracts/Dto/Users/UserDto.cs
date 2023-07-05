namespace Greenmaster.Contracts.Dto.Users;

public class UserDto
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public Guid RoleId { get; set; }
    public RoleDto? Role { get; set; }
    public string Email { get; set; }
    public string? Phone { get; set; }
}