using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Character
{
    [Key]
    public int CharacterId { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    [Required]
    [StringLength(50)]
    public string Alias { get; set; }

    [Required]
    [StringLength(50)]
    public string Gender { get; set; }

    [Required]
    [StringLength(200)]
    public string PictureUrl { get; set; }
    public virtual int MovieId { get; set; }
    public virtual ICollection<Movie>? Movies { get; set; }
}
