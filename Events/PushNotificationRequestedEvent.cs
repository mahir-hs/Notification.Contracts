using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Notification.Contracts.Enums;
using Notification.Contracts.Helpers;
namespace Notification.Contracts.Events;

public class PushNotificationRequestedEvent
{
    public Guid NotificationId { get; set; }
    public Guid UserId { get; set; }
    public string Message { get; set; } = string.Empty;
    public TargetAudience TargetAudience { get; set; }
    public DateTime RequestedAt { get; set; }
}

public static class PushNotificationRequestedEventUtils
{
    public static Dictionary<string, string> ConvertFromObjectToDictionary(this PushNotificationRequestedEvent pushNotificationDto)
    {
        ArgumentNullException.ThrowIfNull(pushNotificationDto);

        return pushNotificationDto.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public)
            .Where(prop => prop.CanRead && prop.Name != nameof(PushNotificationRequestedEvent.TargetAudience))
            .ToDictionary(
                prop => prop.Name.ToCamelCase(),
                prop => prop.PropertyType == typeof(DateTime)
                    ? (prop.GetValue(pushNotificationDto) as DateTime?)?.ToString("o") ?? string.Empty
                    : prop.GetValue(pushNotificationDto)?.ToString() ?? string.Empty
            );
    }
}