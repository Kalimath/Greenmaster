namespace be.Greenmaster.Extensions.Methods;

public static class ExtensionMethods
{
    //Checks if string is valid. If Not valid ArgumentException is thrown
    public static bool ValidateEmptyOrNull(this string validatable)
    {
        return string.IsNullOrWhiteSpace(validatable) ? throw new ArgumentException("Given string is not valid") : true;
    }
    
}