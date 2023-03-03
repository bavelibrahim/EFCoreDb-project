using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Character
{

    public Character()
    {
        Movies = new List<Movie>();
    }

    // The ID of the movie entity as Primary Key.
    [Key]
    public int CharacterId { get; set; }

    // The name of the character.
    [Required]
    [StringLength(50)]
    public string Name { get; set; } = null!;

    // The characters Alias.
    [Required]
    [StringLength(50)]
    public string Alias { get; set; } = null!;

    // The Gender of a character as three choices.
    [Required]
    [StringLength(50)]
    public string Gender { get; set; } = null!;

    // The URL of a character as three choices.
    [Required]
    [StringLength(200)]
    public string PictureUrl { get; set; } = null!;

    //Navigational properties between Character and Movies
    public virtual int MovieId { get; set; }
    public virtual ICollection<Movie>? Movies { get; set; }
}
