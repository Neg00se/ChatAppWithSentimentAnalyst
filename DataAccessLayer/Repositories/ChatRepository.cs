using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories;
public class ChatRepository : IChatRepository
{
	private readonly ChatAppDbContext _context;

	public ChatRepository(ChatAppDbContext context)
	{
		_context = context;
	}


	public async Task<List<Message>> GetAllAsync()
	{
		var messages = await _context.Messages.ToListAsync();
		return messages;
	}

	public async Task CreateAsync(Message message)
	{
		await _context.Messages.AddAsync(message);
		await _context.SaveChangesAsync();
	}
}
