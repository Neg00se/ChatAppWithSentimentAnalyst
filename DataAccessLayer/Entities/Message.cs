using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entities;

public class Message
{
	public int Id { get; set; }

	[MaxLength(20)]
	[Required]
	public string User { get; set; }

	[MaxLength(250)]
	[Required]
	public string Content { get; set; }

	public DateTime DateSent { get; set; } = DateTime.UtcNow;

	[MaxLength(15)]
	public string Sentiment { get; set; }
}
