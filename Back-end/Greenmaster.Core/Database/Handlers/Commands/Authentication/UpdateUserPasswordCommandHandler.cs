using Greenmaster.Contracts.Commands.Authentication;
using Greenmaster.Contracts.Dto.Users;
using Greenmaster.Core.Dxos.Users;
using Greenmaster.Core.Helpers.Authentication;
using Greenmaster.Core.Models.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Greenmaster.Core.Database.Handlers.Commands.Authentication;

public class UpdateUserPasswordCommandHandler : IRequestHandler<UpdateUserPasswordCommand, UserDto>
{
    private readonly IUsersDxos _userDxos;
    private readonly UserManager<User> _userRepository;

    public UpdateUserPasswordCommandHandler(IUsersDxos userDxos, UserManager<User> userRepository)
    {
        _userDxos = userDxos;
        _userRepository = userRepository;
    }
    public async Task<UserDto> Handle(UpdateUserPasswordCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.FindByIdAsync(request.UserId.ToString());
        if (user == null || user.IsDeleted) throw new NullReferenceException("The requested user can not be found/has been deleted");

        if (request.ContextUserId != request.UserId)
            throw new ApplicationException("The token that you used is not yours.");
        if (user.PasswordHash != AuthenticationManager.GenerateHash(request.OldPassword, user.PasswordSalt))
            throw new ApplicationException("Your old password is incorrect.");
        if (user.PasswordHash == AuthenticationManager.GenerateHash(request.NewPassword, user.PasswordSalt))
            throw new ApplicationException("Your new password cannot be the same as your old password.");

        user.PasswordSalt = AuthenticationManager.CreateSalt();
        user.PasswordHash = AuthenticationManager.GenerateHash(request.NewPassword, user.PasswordSalt);

        await _userRepository.UpdateAsync(user);

        return _userDxos.MapUserDto(user);
    }
}