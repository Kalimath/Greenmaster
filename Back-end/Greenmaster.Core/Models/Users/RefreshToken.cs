using Greenmaster.Core.Models.Base;

namespace Greenmaster.Core.Models.Users;

public class RefreshToken: BaseEntity
{
    public Guid UserId { get; set; }
    public User User { get; set; }
    public string Token { get; set; }
    public DateTime Expires { get; set; }

    private bool _isExpired;
    public bool IsExpired
    {
        get => _isExpired;
        set
        {
            if (DateTime.UtcNow >= Expires)
            {
                value = true;
            }
            else
            {
                value = false;
            }
            _isExpired = value;
        }
    }

    public DateTime Created { get; set; }
    public DateTime? Revoked { get; set; }
    public string ReplacedByToken { get; set; }

    private bool _isActive;
    public bool IsActive
    {
        get => _isActive;
        set
        {
            if (Revoked == null && !IsExpired)
            {
                value = true;
            }
            else
            {
                value = false;
            }
            _isActive = value;
        }
    }
    // public bool IsActive => Revoked == null && !IsExpired;

    public RefreshToken()
    {
    }

    public RefreshToken(Guid userId, string token, DateTime expires, DateTime created)
    {
        UserId = userId;
        Token = token;
        Expires = expires;
        Created = created;
    }
}