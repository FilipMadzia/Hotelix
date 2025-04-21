using System.ComponentModel.DataAnnotations;

namespace Hotelix.Api.Data.Entities;

public abstract class Entity
{
	[Key]
	public Guid Id { get; set; } = Guid.NewGuid();

	public DateTime CreatedAt { get; private set; } = DateTime.Now;
	public DateTime UpdatedAt { get; set; }
	public bool SoftDeleted { get; set; }
}
