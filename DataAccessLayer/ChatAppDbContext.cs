using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer;
public class ChatAppDbContext : DbContext
{

	public ChatAppDbContext(DbContextOptions<ChatAppDbContext> options) : base(options)
	{

	}

	public DbSet<Message> Messages { get; set; }



}
