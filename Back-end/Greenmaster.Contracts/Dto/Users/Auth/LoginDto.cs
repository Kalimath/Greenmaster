namespace Greenmaster.Contracts.Dto.Users.Auth;

public class LoginDto : UserDto
{
    public Guid Id { get; set; }
    public string JwtToken { get; set; }
    public DateTime? ResetTokenUsed { get; set; }
    public string RefreshToken { get; set; }

}