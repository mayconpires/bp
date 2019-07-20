using System;
using System.Collections.Generic;
using System.Text;

namespace BP.Domain.Shared.Notification
{
    public class NotificationDomainService : INotificationDomainService
    {
        private List<NotificationItem> _notifications = new List<NotificationItem>();
        public IReadOnlyCollection<NotificationItem> Notifications
        {
            get => _notifications.AsReadOnly();
        } 

        public void Add(string code, string value)
        {
            var notificationItem = NotificationItem.Create(code: code, value: value);
            _notifications.Add(notificationItem);
        }

        public bool IsValid()
        {
            return Notifications.Count == 0;
        }

    }
}
