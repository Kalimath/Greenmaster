using System.ComponentModel.DataAnnotations;

namespace Greenmaster_ASP.Helpers.Attributes;

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

        if (values.All(v => v == null || (v is string && string.IsNullOrWhiteSpace(v as string))))
        {
            return new ValidationResult(ErrorMessage);
        }

        return ValidationResult.Success;
    }
}