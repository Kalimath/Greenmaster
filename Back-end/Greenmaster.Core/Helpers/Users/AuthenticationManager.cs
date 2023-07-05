using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Greenmaster.Core.Models.Users;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Greenmaster.Core.Helpers.Users;

public static class AuthenticationManager
{
    static IConfiguration conf = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

        public static string RandomTokenString()
        {
            using var rngCryptoServiceProvider = RandomNumberGenerator.Create();
            var randomBytes = new byte[40];
            rngCryptoServiceProvider.GetBytes(randomBytes);
            // convert random bytes to hex string
            return BitConverter.ToString(randomBytes).Replace("-", "");
        }


        #region Passwords
        public static string CreateSalt()
        {
            //Generate a cryptographic random number.
            var rng = RandomNumberGenerator.Create();
            var buff = new byte[15];
            rng.GetBytes(buff);
            return Convert.ToBase64String(buff);
        }
        public static string GenerateHash(string input, string salt)
        {
            var bytes = Encoding.UTF8.GetBytes(input + salt);
            var sHA256 = SHA256.Create();
            var hash = sHA256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
        public static bool AreEqual(string plainTextInput, string hashedInput, string salt)
        {
            string newHashedPin = GenerateHash(plainTextInput, salt);
            return newHashedPin.Equals(hashedInput);
        }
        #endregion

        #region Tokens
        public static string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(conf["Secret"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public static RefreshToken GenerateRefreshToken(User user)
        {
            return new RefreshToken
            {
                UserId = user.Id,
                Token = RandomTokenString(),
                Expires = DateTime.UtcNow.AddDays(7),
                Created = DateTime.UtcNow
            };
        }
        
        public static void RemoveOldRefreshTokens(User user)
        {
            user.RefreshTokens.RemoveAll(token => !token.IsActive && token.Created.AddDays(7) <= DateTime.UtcNow);
        }

        public static void RevokeDescendantRefreshTokens(RefreshToken refreshToken, User user)
        {
            // recursively traverse the refresh token chain and ensure all descendants are revoked
            if (!string.IsNullOrEmpty(refreshToken.ReplacedByToken))
            {
                var childToken = user.RefreshTokens.SingleOrDefault(x => x.Token == refreshToken.ReplacedByToken);
                if (childToken.IsActive)
                    RevokeRefreshToken(childToken);
                else
                    RevokeDescendantRefreshTokens(childToken, user);
            }
        }

        public static void RevokeRefreshToken(RefreshToken token, string replacedByToken = null)
        {
            token.Revoked = DateTime.UtcNow;
            token.ReplacedByToken = replacedByToken;
        }
        #endregion
}