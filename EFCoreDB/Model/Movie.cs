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

    public virtual ICollection<Movie>? Movies { get; set; }
    public virtual ICollection<Franchise>? Franchies { get; set; }
}
