using Microsoft.AspNetCore.SignalR;

namespace SignalRChat.Hubs {
    public class ChatHub : Hub {
        public async Task SendMessage(string user, string message) {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
            await Clients.Caller.SendAsync("ReceiveMessage", user, message);
        }
        public async Task SendMessageTwo(byte user, string message) {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
            await Clients.Caller.SendAsync("ReceiveMessage", user, message);
        }
        public async Task SendMessageThree(byte user, byte message) {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
            await Clients.Caller.SendAsync("ReceiveMessage", user, message);
        }
    }
}