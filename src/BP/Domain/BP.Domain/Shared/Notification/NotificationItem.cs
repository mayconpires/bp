using System;
using System.Collections.Generic;
using System.Text;

namespace BP.Domain.Shared.Notification
{
    public class NotificationItem
    {
        public string Code { get; set; }
        public string Value { get; set; }

        private NotificationItem()
        {
        }

        public static NotificationItem Create(string code, string value)
        {
            return new NotificationItem
            {
                Code = code,
                Value = value
            };
        }

    }
}
