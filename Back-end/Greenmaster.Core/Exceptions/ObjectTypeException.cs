namespace Greenmaster.Core.Exceptions;

public class ObjectTypeException : ArgumentException
{
    public ObjectTypeException(string? message) : base(message)
    {
    }

    public ObjectTypeException(string? message, string? paramName) : base(message, paramName)
    {
    }
}