namespace Greenmaster.Repo.FileTransformers;

public static class JsonConverter
{
    /*
     * Converts all json-files in map to one single instance
     */
    public static void ConvertJsonsToOne(string path)
    {
        throw new NotImplementedException();
        /*string json = @"{ 'name': 'Admin' }{ 'name': 'Publisher' }";
        
        IList<Role> roles = new List<Role>();
        
        JsonTextReader reader = new JsonTextReader(new StringReader(json));
        reader.SupportMultipleContent = true;
        
        while (true)
        {
            if (!reader.Read())
            {
                break;
            }
        
            JsonSerializer serializer = new JsonSerializer();
            Role role = serializer.Deserialize<Role>(reader);
        
            roles.Add(role);
        }
        
        foreach (Role role in roles)
        {
            Console.WriteLine(role.Name);
        }
        
        // Admin
        // Publisher*/
    }
        
}