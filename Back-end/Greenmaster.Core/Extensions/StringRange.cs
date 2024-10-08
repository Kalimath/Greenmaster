﻿using System.ComponentModel.DataAnnotations;

namespace Greenmaster.Core.Extensions;

public class StringRange : ValidationAttribute
{
    public string[] AllowableValues { get; set; }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (AllowableValues?.Contains(value?.ToString()) == true)
        {
            return ValidationResult.Success;
        }

        var msg =
            $"Please enter one of the allowable values: {string.Join(", ", (AllowableValues ?? new[] { "No allowable values found" }))}.";
        return new ValidationResult(msg);
    }
}