// 024RegraNegocioNotificacoes
//...https://desenvolvedor.io/curso/dominando-o-asp-net-mvc-core/desenvolvendo-uma-aplicacao-mvc-core-completa/regras-de-negocio-e-eventos-de-notificacoes
using System.Collections.Generic;
using System.Linq;
using Inspecoes.Interfaces;

namespace Inspecoes.Notifications
{
    public class Notifier : INotifier
    {
        private List<Notification> _notifications;

        public Notifier()
        {
            _notifications = new List<Notification>();
        }

        public void Handle(Notification notification)
        {
            _notifications.Add(notification);
        }

        public void Handle(string notification)
        {
            Handle(new Notification(notification));
        }

        public List<Notification> GetNotifications()
        {
            return _notifications;
        }

        public bool HasNotification()
        {
            return _notifications.Any();
        }
    }
}