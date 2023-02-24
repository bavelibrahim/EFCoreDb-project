using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Movie
{
    [Key]
    public int MovieId { get; set; }

    [Required]
    public string Title { get; set; }

    [Required]
    public string Genre { get; set; }

    [Required]
    public string ReleaseYear { get; set; }

    [Required]
    public string Director { get; set; }

    [Required]
    public string Picture { get; set; }

    [Required]
    public string Trailer { get; set; }

    // Navigation properties to be able to navigate to Franchise (Example on Modelbuilder in MyDBContext Class
    public int FranchiseId { get; set; }
    public virtual Franchise Franchise { get; set; }

    public virtual ICollection<Character>? Characters { get; set; } = new List<Character>();

}
