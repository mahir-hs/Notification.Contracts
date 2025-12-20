using System;
using Notification.Contracts.Enums;
namespace Notification.Contracts.Events;

public class PushNotificationRequestedEvent
{
    public Guid NotificationId { get; set; }
    public Guid UserId { get; set; }
    public string Message { get; set; } = string.Empty;
    public TargetAudience TargetAudience { get; set; }
    public DateTime RequestedAt { get; set; }
}
