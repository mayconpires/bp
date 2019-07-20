using System;
using System.Collections.Generic;
using System.Text;

namespace BP.Domain.Shared.Notification
{
    public interface INotificationDomainService
    {
        IReadOnlyCollection<NotificationItem> Notifications { get; }
        void Add(string code, string value);
        bool IsValid();
    }
}
