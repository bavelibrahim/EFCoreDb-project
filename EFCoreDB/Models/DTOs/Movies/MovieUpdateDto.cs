using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class MovieUpdateDto
{

    public string PictureUrl { get; set; }
    public string TrailerUrl { get; set; }
    public int FranchiseId { get; set; }
    public virtual ICollection<CharacterDto>? Characters { get; set; } = new List<CharacterDto>();

}
