using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Greenmaster.Core.Models.Users;

public sealed class User : IdentityUser<Guid>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        [Required]
        public string? ResetToken { get; set; }
        public DateTime? ResetTokenExpires { get; set; }
        public DateTime ResetTokenUsed { get; set; }
        public string PasswordSalt { get; set; }
        public string? Phone { get; set; }
        public List<RefreshToken> RefreshTokens { get; set; }

        public bool IsDeleted { get; private set; }

        public User(string? firstName, string? lastName, string email, string? phone)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            NormalizedEmail = email.ToUpper();
            UserName = email;
            NormalizedUserName = email.ToUpper();
            EmailConfirmed = false;
            PhoneNumberConfirmed = false;
            Phone = phone;
            SecurityStamp = new Guid().ToString();
        }

        public User(string email)
        {
            Email = email;
        }

        public bool OwnsRefreshToken(string token)
        {
            return RefreshTokens?.Select(x => x.Token == token) != null;
        }

        public string ActiveRefreshToken()
        {
            var token = RefreshTokens.First(t => t.IsActive && !t.IsExpired);
            return token.Token;
        }

        public void AddToken(RefreshToken token)
        {
            if (RefreshTokens == null) RefreshTokens = new List<RefreshToken>();
            RefreshTokens.Add(token);
        }
        public void Delete()
        {
            IsDeleted = true;
        }
    }