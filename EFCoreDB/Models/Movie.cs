using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Movie
{
    public Movie()
    {
        Characters = new List<Character>();
    }

    // The ID of the movie entity as Primary Key.
    [Key]
    public int MovieId { get; set; }

    // The Title of the movie.
    [Required]
    [StringLength(50)]
    public string Title { get; set; } = null!;

    // The genre of the movie.
    [Required]
    [StringLength(50)]
    public string Genre { get; set; } = null!;

    // The year the movie was released.
    [Required]
    [Range(1900, 2023)]
    public string ReleaseYear { get; set; } = null!;

    // Director of the movie.
    [Required]
    [StringLength(50)]
    public string Director { get; set; } = null!;

    // The URL of the picture for the movie.
    [Required]
    [StringLength(200)]
    public string PictureUrl { get; set; } = null!;

    // The URL of the trailer for the movie.
    [Required]
    [StringLength(200)]
    public string TrailerUrl { get; set; } = null!;

    // Navigation properties to be able to navigate to Franchise (Example on Modelbuilder in MyDBContext Class
    public int FranchiseId { get; set; }
    public virtual Franchise? Franchise { get; set; } = null!;
    public virtual ICollection<Character>? Characters { get; set; }

}
