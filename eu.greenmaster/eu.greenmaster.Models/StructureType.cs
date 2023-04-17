namespace eu.greenmaster.Models;

public class StructureType : ObjectType
{
    public StructureType()
    {
        
    }
    public StructureType(int id, string name, string? description = "/"): base(id, name, description)
    {
    }
}