using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Franchise
{
    public Franchise()
    {
        Movies = new HashSet<Movie>();
    }

    // The ID of the franchise as Primary Key.
    [Key]
    public int FranchiseId { get; set; }

    // The ConnectionString of the franchise.
    [Required]
    [StringLength(50)]
    public string Name { get; set; } = null!;

    // The Description of the franchise.
    [Required]
    [StringLength(500)]
    public string Description { get; set; } = null!;

    // Collections for movies
    public virtual ICollection<Movie>? Movies { get; set; }

}
