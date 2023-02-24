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
    [Range(1900, DateTime.Now.Year)]
    public string ReleaseYear { get; set; }

    // Director of the movie.
    [Required]
<<<<<<< HEAD:EFCoreDB/Models/Movie.cs
=======
    [StringLength(50)]
>>>>>>> 81f0ec1c4c15d9b739067c22d5dc385ff472b389:EFCoreDB/Model/Movie.cs
    public string Director { get; set; }

    // The URL of the picture for the movie.
    [Required]
    [StringLength(200)]
    public string Picture { get; set; }

    // The URL of the trailer for the movie.
    [Required]
    [StringLength(200)]
    public string Trailer { get; set; }

<<<<<<< HEAD:EFCoreDB/Models/Movie.cs
    // Navigation properties to be able to navigate to Franchise (Example on Modelbuilder in MyDBContext Class
    public int FranchiseId { get; set; }
    public virtual Franchise Franchise { get; set; }

    public virtual ICollection<Character>? Characters { get; set; } = new List<Character>();

=======
    // Collections for movies and franchises.
    public virtual ICollection<Movie>? Movies { get; set; }
    public virtual ICollection<Franchise>? Franchies { get; set; }
>>>>>>> 81f0ec1c4c15d9b739067c22d5dc385ff472b389:EFCoreDB/Model/Movie.cs
}
