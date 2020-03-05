using Microsoft.AspNet.SignalR;

namespace Sindicato_v1.Hubs
{
    public class NotificationsHub : Hub
    {
        public static void Show()
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<NotificationsHub>();
            context.Clients.All.displayNotifications();
        }
    }
}