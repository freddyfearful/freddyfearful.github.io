using Microsoft.AspNetCore.SignalR;
using SignalRChat.Hubs;

public class ThreadStartService : BackgroundService {
    private readonly IHubContext<ChatHub> hubContext;
    private readonly int updateTimeMilliseconds = 1000;

    public ThreadStartService(IHubContext<ChatHub> hubContext) { this.hubContext = hubContext; }
 
    protected override async Task ExecuteAsync(CancellationToken stoppingToken) {
        while (!stoppingToken.IsCancellationRequested) {
            Server.Update(updateTimeMilliseconds / 1000);
            hubContext.Clients.All.SendAsync("ReceiveMessage", "Server", "Updated" + Server.num);

            await Task.Delay(TimeSpan.FromMilliseconds(updateTimeMilliseconds), stoppingToken); // an attempt to make the server run less and save money
        }
    }

    //private async Task UpdateClientsAsync() {
    //    // Logic to gather updates and send to clients
    //    await hubContext.Clients.All.SendAsync("ReceiveMessage", "Server", "Update message");
    //}
}