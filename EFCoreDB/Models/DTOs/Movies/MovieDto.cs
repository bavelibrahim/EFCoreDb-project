/// <summary>
/// General DTO for Movie, which includes all related data as Ids.
/// </summary>
public class MovieDto
{
    public int MovieId { get; set; }
    public string Title { get; set; } = null!;
    public string Genre { get; set; } = null!;
    public string ReleaseYear { get; set; } = null!;
    public string Director { get; set; } = null!;
    public string PictureUrl { get; set; } = null!;
    public string TrailerUrl { get; set; } = null!;
    public int FranchiseId { get; set; }
    public virtual Franchise Franchise { get; set; } = null!;
    public virtual List<int> Characters { get; set; } = null!;

}