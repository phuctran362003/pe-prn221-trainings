using System.ComponentModel.DataAnnotations;

namespace Repository.Entities;

public partial class Equipment
{
    [Required]

    public int EqId { get; set; }
    [Required]

    public string EqCode { get; set; } = null!;
    [Required]
    [RegularExpression(@"^(?:[A-Z][a-zA-Z0-9@#$&()]*\s?){1,9}$", ErrorMessage = "Each word must start with a capital letter and be less than 10 characters, allowing letters, numbers, and special characters.")]
    public string? EqName { get; set; }
    [Required]

    public string? Description { get; set; }
    [Required]

    public string? Model { get; set; }
    [Required]

    public string? SupplierName { get; set; }
    [Required]

    public DateTime? CreatedAt { get; set; } = DateTime.Now;
    [Required]

    public DateTime? UpdatedAt { get; set; }
    [Required]
    [Range(1, 100, ErrorMessage = "Number must be between 1 and 100.")]
    public int? Quantity { get; set; }
    [Required]

    public int? Status { get; set; }
    [Required]

    public int? RoomId { get; set; }

    public virtual Room? Room { get; set; }
}
