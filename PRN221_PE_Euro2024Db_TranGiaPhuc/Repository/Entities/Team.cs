using System.ComponentModel.DataAnnotations;

namespace Repository.Entities;

public partial class Team
{
    [Required(ErrorMessage = "Team Id is required")]
    public int Id { get; set; }

    [Required(ErrorMessage = "Team Name is required")]
    [RegularExpression(@"^([A-Z][a-zA-Z0-9]*\s?)+$", ErrorMessage = "Each word in Team Name must begin with a capital letter and include only letters and digits.")]
    [StringLength(10, MinimumLength = 3, ErrorMessage = "Team Name must be between 3 and 10 characters.")]
    public string TeamName { get; set; } = null!;

    [Required(ErrorMessage = "Point is required")]
    public PointEnum Point { get; set; }

    public int? GroupId { get; set; }

    public int Position { get; set; }

    public virtual GroupTeam? Group { get; set; }

    public void UpdatePositionBasedOnPoints()
    {
        // Logic to update the position based on points
    }
}

public enum PointEnum
{
    Zero = 0,
    One = 1,
    Three = 3
}

