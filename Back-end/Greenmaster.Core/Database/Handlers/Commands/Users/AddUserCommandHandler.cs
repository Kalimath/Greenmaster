using FluentValidation;
using Greenmaster.Contracts.Commands.Users;
using Greenmaster.Contracts.Dto.Users;
using Greenmaster.Core.Communication.Mail;
using Greenmaster.Core.Dxos.Users;
using Greenmaster.Core.Helpers.Authentication;
using Greenmaster.Core.Models.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;
using StaticData.Communication.Mail;

namespace Greenmaster.Core.Database.Handlers.Commands.Users;

public class AddUserCommandHandler : IRequestHandler<AddUserCommand, UserDto>
    {
        private readonly UserManager<User> _userRepository;
        private readonly RoleManager<Role> _roleRepository;
        private readonly IUsersDxos _userDxos;
        private readonly IMailService _mailService;

        public AddUserCommandHandler(UserManager<User> userRepository, RoleManager<Role> roleRepository, IUsersDxos usersDxos, IMailService mailService)
        {
            this._userRepository = userRepository;
            this._roleRepository = roleRepository;
            _userDxos = usersDxos;
            this._mailService = mailService;
        }

        public async Task<UserDto> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var result = await new AddUserCommandValidator().ValidateAsync(request);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
            var userExists = await _userRepository.FindByEmailAsync(request.Email);
            if (userExists != null)
            {
                throw new ApplicationException("User already exists");
            }

            var user = new User(request.FirstName, request.LastName, request.Email, request.Phone);
            user.ResetToken = AuthenticationManager.RandomTokenString();
            user.ResetTokenExpires = DateTime.Now.AddDays(7);

            //send mail to user to fully register
            var role = await _roleRepository.FindByIdAsync(request.RoleId.ToString());
            if (role == null)
            {
                throw new NullReferenceException();
            }
            
            await _userRepository.CreateAsync(user);
            await _userRepository.AddToRoleAsync(user, role.Name);
            _mailService.SendAsync("Confirmation of registration", MailType.CONFIRMATION_MAIL, user);

            return _userDxos.MapUserDto(user);

        }
    }