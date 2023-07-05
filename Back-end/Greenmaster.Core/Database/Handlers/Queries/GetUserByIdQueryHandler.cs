using Greenmaster.Contracts.Dto.Users;
using Greenmaster.Core.Database.Queries.Users;
using Greenmaster.Core.Dxos.Users;
using Greenmaster.Core.Models.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Greenmaster.Core.Database.Handlers.Queries;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto>
{
    private readonly UserManager<User> _userRepository;
    private readonly RoleManager<Role> _roleRepository;
    private readonly IUsersDxos _usersDxo;

    public GetUserByIdQueryHandler(UserManager<User> userRepository, RoleManager<Role> roleRepository, IUsersDxos usersDxo)
    {
        _userRepository = userRepository;
        _roleRepository = roleRepository;
        _usersDxo = usersDxo;
    }

    public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.FindByIdAsync(request.Id.ToString());
        if (user == null)
        {
            throw new NullReferenceException("User not found");
        }

        var roleName = (await _userRepository.GetRolesAsync(user)).FirstOrDefault();
        var role = await _roleRepository.FindByNameAsync(roleName);
        if (role == null)
        {
            throw new NullReferenceException();
        }

        var dto = _usersDxo.MapUserDto(user);
        dto.RoleId = role.Id;
        return dto;
    }
}