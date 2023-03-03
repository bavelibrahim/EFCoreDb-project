namespace EFCoreDB.Models.DTOs.Movies
{
    /// <summary>
    /// DTO for a movie without any related data.
    /// </summary>
    public class MovieSummaryDto
    {
        public int MovieId { get; set; }
        public string Title { get; set; } = null!;
        public string Genre { get; set; } = null!;
    }
}
