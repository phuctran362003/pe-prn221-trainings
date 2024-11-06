using System.ComponentModel.DataAnnotations;

namespace Repository.Entities;

public partial class Team
{
    [Required(ErrorMessage = "Team Id is required")]
    public int Id { get; set; }

    [Required(ErrorMessage = "Team Name is required")]
    [RegularExpression(@"^[A-Z][a-z]*$", ErrorMessage = "Must begin capital letter")]
    public string TeamName { get; set; } = null!;

    [Required(ErrorMessage = "Quantity is required")]
    [Range(1, 50, ErrorMessage = "Quantity must be between 1 and 50")]
    public int Point { get; set; }

    public int? GroupId { get; set; }

    public int Position { get; set; }

    public virtual GroupTeam? Group { get; set; }
}
