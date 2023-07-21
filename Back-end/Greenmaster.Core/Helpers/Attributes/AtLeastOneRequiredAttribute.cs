using System.ComponentModel.DataAnnotations;

namespace Greenmaster.Core.Helpers.Attributes;

public class AtLeastOneRequiredAttribute : ValidationAttribute
{
    private readonly string[] _propertyNames;

    public AtLeastOneRequiredAttribute(string[] propertyNames)
    {
        _propertyNames = propertyNames;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var properties = _propertyNames.Select(validationContext.ObjectType.GetProperty);

        var values = properties.Select(p => p.GetValue(validationContext.ObjectInstance, null));

        return (values.All(v => v == null || (v is string && string.IsNullOrWhiteSpace(v as string))) ? new ValidationResult(ErrorMessage) : ValidationResult.Success)!;
    }
}