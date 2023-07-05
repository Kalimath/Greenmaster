namespace Greenmaster.Core.Models.Users;

public static class Permission
{
    public static List<string> AllModules => new() { "Species", "PlantTypes", "Materials", "Placeables", "ObjectTypes", "GardenStyles", "Users" };
    public static List<string> GenerateAllPermissionsForModule(string module)
    {
        return new List<string>(){
            GenerateCreatePermissionForModule(module),
            GenerateReadPermissionForModule(module),
            GenerateEditPermissionForModule(module),
            GenerateDeletePermissionForModule(module)};
    }
    public static string GenerateCreatePermissionForModule(string module)
    {
        return $"Permissions.{module}.Create";
    }
    public static string GenerateReadPermissionForModule(string module)
    {
        return $"Permissions.{module}.Read";
    }

    public static string GenerateEditPermissionForModule(string module)
    {
        return $"Permissions.{module}.Edit";
    }

    public static string GenerateDeletePermissionForModule(string module)
    {
        return $"Permissions.{module}.Delete";
    }
}