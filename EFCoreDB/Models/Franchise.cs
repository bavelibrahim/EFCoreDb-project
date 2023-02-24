using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Franchise
{
    // The ID of the franchise as Primary Key.
    [Key]
    public int FranchiseId { get; set; }

    // The Name of the franchise.
    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    // The Description of the franchise.
    [Required]
    [StringLength(500)]
    public string Description { get; set; }

    // Collections for movies
    public virtual ICollection<Movie> Movies { get; set; }

}
