using System.ComponentModel.DataAnnotations.Schema;

namespace Hotelix.API.Data.Entities;

[Table("Cities")]
public class CityEntity : BaseEntity
{
	public required string Name { get; set; }
}
