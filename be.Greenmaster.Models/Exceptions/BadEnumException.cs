using System.ComponentModel;

namespace be.Greenmaster.Models.Exceptions;

public class BadEnumException : InvalidEnumArgumentException
{
    public BadEnumException()
    {
    }

    public BadEnumException(string? message) : base(message)
    {
    }
}