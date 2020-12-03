using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace gtbweb.Services.SignalRService.Hubs
{
    public class ServiceHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
