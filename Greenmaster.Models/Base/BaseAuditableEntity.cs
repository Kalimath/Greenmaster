namespace Greenmaster.Models.Base;

public abstract class BaseAuditableEntity : BaseEntity
{
    public DateTime Created { get; set; }
    public DateTime Modified { get; set; }
}