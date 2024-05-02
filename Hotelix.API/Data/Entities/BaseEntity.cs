using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotelix.API.Data.Entities;

public abstract class BaseEntity
{
	[Key]
	public int Id { get; set; }
	public DateTime CreatedAt { get; private set; }
	public DateTime UpdatedAt { get; set; }
	public bool SoftDeleted { get; set; }

	public BaseEntity()
	{
		CreatedAt = DateTime.Now;
		UpdatedAt = DateTime.Now;
	}
}
