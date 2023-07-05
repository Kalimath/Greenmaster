namespace Greenmaster.Core.Models;

public class StructureType : ObjectType
{
    public StructureType()
    {
        
    }
    public StructureType(Guid id, string name, string? description = "/"): base(id, name, description)
    {
    }
}