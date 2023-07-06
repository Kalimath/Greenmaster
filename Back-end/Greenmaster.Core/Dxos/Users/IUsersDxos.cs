using AutoMapper;
using Greenmaster.Contracts.Dto.Users;
using Greenmaster.Contracts.Dto.Users.Auth;
using Greenmaster.Core.Models.Users;

namespace Greenmaster.Core.Dxos.Users;

public interface IUsersDxos
{
    UserDto MapUserDto(User user);
    IEnumerable<UserDto> MapUserDtos(IEnumerable<User> users);

    LoginDto MapLoginDto(User user);
}

public class UsersDxos : IUsersDxos
{
    private readonly IMapper _mapper;

    public UsersDxos()
    {
        var config = new MapperConfiguration(cfg => 
        { cfg.CreateMap<User, UserDto>(); 
            cfg.CreateMap<UserDto, User>(); 
            cfg.CreateMap<User, LoginDto>();
            cfg.CreateMap<Role, RoleDto>(); 
        });
        _mapper = config.CreateMapper();
    }

    public LoginDto MapLoginDto(User user)
    {
        return _mapper.Map<LoginDto>(user);
    }

    public UserDto MapUserDto(User user)
    {
        return _mapper.Map<User, UserDto>(user);
    }
    
    public IEnumerable<UserDto> MapUserDtos(IEnumerable<User> users)
    {
        return _mapper.Map<IEnumerable<UserDto>>(users);
    }
}