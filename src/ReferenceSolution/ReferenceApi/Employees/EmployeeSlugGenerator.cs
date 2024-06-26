﻿
namespace ReferenceApi.Employees;

public class EmployeeSlugGenerator
{
    public string Generate(string firstName, string? lastName)
    {

        var slug = (Clean(firstName), Clean(lastName)) switch
        {
            (string first, null) => first,
            (string first, string last) => $"{last}-{first}",
            _ => throw new InvalidOperationException() // Chaos
        };
        return slug;
    }

    // Never type private, always refactor to it.
    private static string? Clean(string? part)
    {
        if (string.IsNullOrWhiteSpace(part))
        {
            return null;
        }
        return part.ToLowerInvariant().Trim();
    }
}
