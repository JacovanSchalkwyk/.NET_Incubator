using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Common.Entities;

public class Pizza
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int Id { get; set; }

	public required string Name { get; set; }

	public string? Description { get; set; }

	public decimal Price { get; set; }

	public DateTime? DateCreated { get; set; }
}
