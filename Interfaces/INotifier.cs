using System.Collections.Generic;
using Inspecoes.Notifications;

namespace Inspecoes.Interfaces
{
    public interface INotifier
    {
        bool HasNotification();
        List<Notification> GetNotifications();
        void Handle(Notification notification);
        void Handle(string notification);
    }
}