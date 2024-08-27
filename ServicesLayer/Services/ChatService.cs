using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using ServicesLayer.Interfaces;

namespace ServicesLayer.Services;
public class ChatService : IChatService
{
	private readonly IChatRepository _chatRepo;
	private readonly SentimentAnalysisService _analysisService;

	public ChatService(IChatRepository chatRepo, SentimentAnalysisService analysisService)
	{
		_chatRepo = chatRepo;
		_analysisService = analysisService;
	}

	public async Task<List<Message>> GetAllMessagesAsync()
	{
		var messages = await _chatRepo.GetAllAsync();

		return messages;
	}

	public async Task AddMessage(string user, string message)
	{
		Message msg = new Message();
		msg.User = user;
		msg.Content = message;
		msg.Sentiment = await _analysisService.Analyze(message);

		await _chatRepo.CreateAsync(msg);
	}
}
