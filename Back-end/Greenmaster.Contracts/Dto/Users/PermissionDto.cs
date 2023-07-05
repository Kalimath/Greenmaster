namespace Greenmaster.Contracts.Dto.Users;

public class PermissionDto
{
    public string Module { get; set; }
    public IEnumerable<string> Permissions { get; set; }
    public PermissionDto(string module, IEnumerable<string> permissions)
    {
        Module = module;
        Permissions = permissions;
    }
}