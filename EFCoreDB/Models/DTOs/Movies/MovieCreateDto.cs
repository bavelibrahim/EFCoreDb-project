

/// <summary>
/// DTO for the process of adding a new Movie.
/// </summary>

public class MovieCreateDto
{
    public string Title { get; set; } = null!;
    public string Genre { get; set; } = null!;
    public string ReleaseYear { get; set; } = null!;
    public string Director { get; set; } = null!;
    public string PictureUrl { get; set; } = null!;
    public string TrailerUrl { get; set; } = null!;
    public int FranchiseId { get; set; }
}
