using DataAccessLayer.Entities;

namespace ServicesLayer.Interfaces;
public interface IChatService
{
	Task AddMessage(string user, string message);
	Task<List<Message>> GetAllMessagesAsync();
}