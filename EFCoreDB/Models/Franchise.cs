using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Franchise
{
    [Key]
    public int FranchiseId { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Description { get; set; }

    public virtual ICollection<Movie> Movies { get; set; }

}
