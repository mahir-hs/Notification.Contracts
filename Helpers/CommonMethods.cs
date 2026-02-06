using System;
using System.Text;

namespace Notification.Contracts.Helpers;

public static class CommonMethods
{
    public static DateTime GetCurrentBDTime()
    {
        return DateTime.UtcNow.Add(TimeSpan.FromHours(6));
    }

    public static string ToCamelCase(this string pascalCase)
    {
        if (string.IsNullOrEmpty(pascalCase))
        {
            return pascalCase;
        }

        var builder = new StringBuilder(pascalCase);
        builder[0] = char.ToLowerInvariant(builder[0]);
        return builder.ToString();
    }
}
