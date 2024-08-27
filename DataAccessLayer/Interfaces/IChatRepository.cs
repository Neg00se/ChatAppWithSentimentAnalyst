using DataAccessLayer.Entities;

namespace DataAccessLayer.Interfaces;
public interface IChatRepository
{
	Task CreateAsync(Message message);
	Task<List<Message>> GetAllAsync();
}