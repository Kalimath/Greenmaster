using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Greenmaster.Core.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace Greenmaster.ArboretumWebService.Middleware;

public interface IJwtMiddleware
{
    Task Invoke(HttpContext context);
}
public class JwtMiddleware : IJwtMiddleware
    {
        private readonly RequestDelegate _next = null!;
        static IConfiguration conf = (new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build());

        public JwtMiddleware()
        {
        }

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
                await AttachAccountToContext(context, token);

            await _next(context);
        }

        private async Task AttachAccountToContext(HttpContext context, string token)
        {
            var _path = context.Request.Path;
            var _token = token;
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(conf["Secret"]);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = false, 
                    ClockSkew = TimeSpan.Zero
                }, out var validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = Guid.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

                // creates a new instance of userManager, to create new connection to DB and avoid concurrent calls.
                var userService = context.RequestServices.GetRequiredService<UserManager<User>>();
                var user = await userService.FindByIdAsync(userId.ToString());

                // attach user to context on successful jwt validation
                context.Items["User"] = user;
                var user2 = context.Items["User"];
                var path2 = context.Request.Path;
                var context2 = context;
                // var url = context.HttpContext.Request.Path;
            }
            catch
            {
                // do nothing if jwt validation fails
                // account is not attached to context so request won't have access to secure routes
            }
        }
    }