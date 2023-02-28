using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Movie
{
    // The ID of the movie entity as Primary Key.
    [Key]
    public int MovieId { get; set; }

    // The Title of the movie.
    [Required]
    [StringLength(50)]
    public string Title { get; set; }

    // The genre of the movie.
    [Required]
    [StringLength(50)]
    public string Genre { get; set; }

    // The year the movie was released.
    [Required]
    [Range(1900, 2023)]
    public string ReleaseYear { get; set; }

    // Director of the movie.
    [Required]
    [StringLength(50)]
    public string Director { get; set; }

    // The URL of the picture for the movie.
    [Required]
    [StringLength(200)]
    public string PictureUrl { get; set; }

    // The URL of the trailer for the movie.
    [Required]
    [StringLength(200)]
    public string TrailerUrl { get; set; }

    // Navigation properties to be able to navigate to Franchise (Example on Modelbuilder in MyDBContext Class
    public int FranchiseId { get; set; }
    public virtual Franchise Franchise { get; set; }
    public virtual ICollection<Character>? Characters { get; set; } = new List<Character>();

}
