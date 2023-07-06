using Greenmaster.Contracts.Dto.Users;
using Greenmaster.Contracts.Queries.Users;
using Greenmaster.Core.Dxos.Users;
using Greenmaster.Core.Models.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Greenmaster.Core.Database.Handlers.Queries;

public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<UserDto>>
{
    private readonly UserManager<User> _repository;
    private readonly IUsersDxos _usersDxos;

    public GetAllUsersQueryHandler(UserManager<User> repository, IUsersDxos usersDxo)
    {
        _repository = repository;
        _usersDxos = usersDxo;
    }

    public async Task<IEnumerable<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _repository.Users.ToListAsync(cancellationToken: cancellationToken);
        if (users == null)
        {
            throw new NullReferenceException();
        }
        return _usersDxos.MapUserDtos(users);
    }

}