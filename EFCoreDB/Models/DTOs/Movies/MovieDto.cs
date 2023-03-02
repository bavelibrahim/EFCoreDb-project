public class MovieDto
{
    public int MovieId { get; set; }
    public string Title { get; set; }
    public string Genre { get; set; }
    public string ReleaseYear { get; set; }
    public string Director { get; set; }
    public string PictureUrl { get; set; }
    public string TrailerUrl { get; set; }
    public int FranchiseId { get; set; }
    public virtual Franchise Franchise { get; set; }
}