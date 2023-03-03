using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// DTO for updating an existing Movie. The related data is updated via a separate endpoint.
/// </summary>
public class MovieUpdateDto
{
    public int MovieId { get; set; }
    public string PictureUrl { get; set; } = null!;
    public string TrailerUrl { get; set; } = null!;
    public int FranchiseId { get; set; }

}
