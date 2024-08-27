using Microsoft.AspNetCore.SignalR;
using ServicesLayer.Interfaces;
namespace ChatAppWithSentimentAnalyst.Hubs;

public class ChatHub : Hub
{
	private readonly IChatService _chatService;

	public ChatHub(IChatService chatService)
	{
		_chatService = chatService;
	}

	public override async Task OnConnectedAsync()
	{
		Console.WriteLine("Connected ");
		var messages = await _chatService.GetAllMessagesAsync();
		await Clients.Caller.SendAsync("GetMessages", messages);
	}

	public async Task SendMessage(string user, string message)
	{
		await _chatService.AddMessage(user, message);

		var messages = await _chatService.GetAllMessagesAsync();

		await Clients.All.SendAsync("GetMessages", messages);
	}
}
