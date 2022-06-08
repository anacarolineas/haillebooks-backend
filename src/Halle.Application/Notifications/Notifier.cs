using Halle.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Halle.Application.Notifications
{
    public class Notifier : INotification
    {
        private List<Notification> _notifications = new List<Notification>();

        public List<Notification> GetNotifications() =>
            _notifications;

        public void Handle(Notification notification) =>
            _notifications.Add(notification);
        
        public bool HasNotifications() =>
            _notifications.Any();

    }
   
}
