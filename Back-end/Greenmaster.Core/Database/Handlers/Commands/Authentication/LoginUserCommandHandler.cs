using Greenmaster.Contracts.Commands.Authentication;
using Greenmaster.Core.Dxos.Users;
using Greenmaster.Core.Helpers.Authentication;
using Greenmaster.Core.Models.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Greenmaster.Core.Database.Handlers.Commands.Authentication;

internal class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, Contracts.Dto.Users.Auth.LoginDto>
    {
        private readonly UserManager<User> _userRepository;
        private readonly RoleManager<Role> _roleRepository;
        private readonly IUsersDxos _userDxos;
        private readonly IRolesDxos _rolesDxos;

        public LoginUserCommandHandler(UserManager<User> userRepository, RoleManager<Role> roleRepository, IUsersDxos usersDxos, IRolesDxos rolesDxos)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _userDxos = usersDxos;
            _rolesDxos = rolesDxos;
        }

        public async Task<Contracts.Dto.Users.Auth.LoginDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.FindByEmailAsync(request.Email);
            if (user == null || user.IsDeleted)
            {
                throw new NullReferenceException("User with this email is not found.");
            }
            if (user.PasswordHash == null)
            {
                throw new ApplicationException("User has not set password.");
            }

            if (!AuthenticationManager.AreEqual(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                throw new ApplicationException("Password is not correct.");
            }

            var jwtToken = AuthenticationManager.GenerateJwtToken(user);
            var refreshToken = AuthenticationManager.GenerateRefreshToken(user);
            user.AddToken(refreshToken);

            AuthenticationManager.RemoveOldRefreshTokens(user);

            await _userRepository.UpdateAsync(user);
            
            var roleName = (await _userRepository.GetRolesAsync(user)).FirstOrDefault();
            var role = await _roleRepository.FindByNameAsync(roleName);
            if (role == null)
            {
                throw new NullReferenceException();
            }
            var claims = await _roleRepository.GetClaimsAsync(role);
            var roleDto = _rolesDxos.MapRoleDto(role);
            foreach (var permission in claims)
            {
                roleDto.Permissions.Add(permission.Value);
            }
            var loginDto = _userDxos.MapLoginDto(user);
            loginDto.JwtToken = jwtToken;
            loginDto.RefreshToken = refreshToken.Token;
            loginDto.Role = roleDto;
            loginDto.RoleId = roleDto.Id;
            return loginDto;
        }
    }