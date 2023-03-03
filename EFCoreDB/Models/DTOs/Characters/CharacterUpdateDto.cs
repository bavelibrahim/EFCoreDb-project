public class CharacterUpdateDto
{
    /// <summary>
    /// DTO for updating an existing character. The related data is updated via a separate endpoint.
    /// </summary>
    public int CharacterId { get; set; } 
    public string Name { get; set; } = null!;
    public string Alias { get; set; } = null!;
    public string PictureUrl { get; set; } = null!;
}