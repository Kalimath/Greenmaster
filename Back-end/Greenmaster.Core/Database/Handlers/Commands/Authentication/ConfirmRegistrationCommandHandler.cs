using Greenmaster.Contracts.Commands.Authentication;
using Greenmaster.Contracts.Dto.Users;
using Greenmaster.Core.Dxos.Users;
using Greenmaster.Core.Helpers.Authentication;
using Greenmaster.Core.Models.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Greenmaster.Core.Database.Handlers.Commands.Authentication;

public class ConfirmRegistrationCommandHandler : IRequestHandler<ConfirmRegistrationCommand, UserDto>
{
    private readonly UserManager<User> _userRepository;
    private readonly IUsersDxos _userDxos;

    public ConfirmRegistrationCommandHandler(UserManager<User> userRepository, IUsersDxos usersDxos)
    {
        _userRepository = userRepository;
        _userDxos = usersDxos;
    }
    public async Task<UserDto> Handle(ConfirmRegistrationCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.FindByEmailAsync(request.Email);
        if(user == null || user.IsDeleted || user.ResetToken != request.VerificationToken)
        {
            throw new NullReferenceException("User could not be found (invalid email or verificationtoken)");
        }

        if (user.ResetTokenExpires <= DateTime.UtcNow)
        {
            throw new ApplicationException("Verificationtoken expired");
        }
        user.PasswordSalt = AuthenticationManager.CreateSalt();
        user.PasswordHash = AuthenticationManager.GenerateHash(request.Password, user.PasswordSalt);

        user.ResetToken = null;
        user.ResetTokenExpires = null;
        user.ResetTokenUsed = DateTime.UtcNow;

        await _userRepository.UpdateAsync(user);
        return _userDxos.MapUserDto(user);

    }
}