using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class MovieUpdateDto
{
    public int MovieId { get; set; }
    public string PictureUrl { get; set; }
    public string TrailerUrl { get; set; }
    public int FranchiseId { get; set; }
    public virtual ICollection<CharacterDto>? Characters { get; set; } = new List<CharacterDto>();

}
