using System.ComponentModel.DataAnnotations;

namespace Hotelix.Api.Data.Entities;

public abstract class Entity
{
	[Key]
	public int Id { get; set; }

	public DateTime CreatedAt { get; private set; } = DateTime.Now;
	public DateTime UpdatedAt { get; set; }
	public bool SoftDeleted { get; set; }
}
