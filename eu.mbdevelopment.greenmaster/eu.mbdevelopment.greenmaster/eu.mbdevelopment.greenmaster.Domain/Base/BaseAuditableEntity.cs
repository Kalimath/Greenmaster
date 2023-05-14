using System.ComponentModel.DataAnnotations;

namespace eu.mbdevelopment.greenmaster.Domain.Base;

public abstract class BaseAuditableEntity : BaseEntity
{
    [DataType(DataType.Date)]
    public DateTime Created { get; set; }
    [DataType(DataType.Date)]
    public DateTime Modified { get; set; }
}