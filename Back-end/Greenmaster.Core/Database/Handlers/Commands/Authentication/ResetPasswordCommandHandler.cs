using Greenmaster.Contracts.Commands.Authentication;
using Greenmaster.Contracts.Dto.Users;
using Greenmaster.Core.Communication.Mail;
using Greenmaster.Core.Database.Extensions;
using Greenmaster.Core.Dxos.Users;
using Greenmaster.Core.Helpers.Authentication;
using Greenmaster.Core.Models.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;
using StaticData.Communication.Mail;

namespace Greenmaster.Core.Database.Handlers.Commands.Authentication;

public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, UserDto>
{
    private readonly UserManager<User> _userRepository;
    private readonly IUsersDxos _userDxos;
    private readonly IMailService _mailService;
    public ResetPasswordCommandHandler(UserManager<User> userRepository, IUsersDxos usersDxos, IMailService mailService)
    {
        this._userRepository = userRepository;
        _userDxos = usersDxos;
        _mailService = mailService;
    }
    public async Task<UserDto> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetFullUserByEmailAsync(request.Email);
        if (user == null) throw new ApplicationException("User with this email does not exists");
        user.ResetToken = AuthenticationManager.RandomTokenString();
        user.ResetTokenExpires = DateTime.Now.AddDays(7);
        await _userRepository.UpdateAsync(user);
        _mailService.SendAsync("Confirmation of registration", MailType.RESET_PASSWORD_MAIL, user);

        return _userDxos.MapUserDto(user);
    }
}