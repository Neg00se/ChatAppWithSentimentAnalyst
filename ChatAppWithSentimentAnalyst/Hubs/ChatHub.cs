using Microsoft.AspNetCore.SignalR;
namespace ChatAppWithSentimentAnalyst.Hubs;

public class ChatHub : Hub
{
	public async Task SendMessage(string user, string message)
	{
		await Clients.All.SendAsync("GetMessage", user, message);
	}
}
