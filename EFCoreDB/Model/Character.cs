using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Character
{
    [Key]
    public int CharacterId { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Alias { get; set; }

    [Required]
    public string Gender { get; set; }

    [Required]
    public string Picture { get; set; }

    public virtual ICollection<Movie>? Movies { get; set; }
    public virtual ICollection<Franchise>? Franchises { get; set; }
}
