using Halle.Application.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Halle.Application.Interfaces
{
    public interface INotification
    {
        List<Notification> GetNotifications();
        bool HasNotifications();
        void Handle(Notification notification);

    }
}
