using AutoMapper;
using Greenmaster.Contracts.Dto.Users;
using Greenmaster.Core.Models.Users;

namespace Greenmaster.Core.Dxos.Users;

public interface IRolesDxos
{
    RoleDto MapRoleDto(Role role);
    IEnumerable<RoleDto> MapRoleDtos(IEnumerable<Role> roles);
}

public class RolesDxos : IRolesDxos
{
    private readonly IMapper _mapper;

    public RolesDxos()
    {
        var config = new MapperConfiguration(cfg => { cfg.CreateMap<Role, RoleDto>(); });
        _mapper = config.CreateMapper();
    }

    public RoleDto MapRoleDto(Role role)
    {
        return _mapper.Map<Role, RoleDto>(role);
    }

    public IEnumerable<RoleDto> MapRoleDtos(IEnumerable<Role> roles)
    {
        return _mapper.Map<IEnumerable<RoleDto>>(roles);
    }
}