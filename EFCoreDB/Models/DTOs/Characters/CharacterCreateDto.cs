public class CharacterCreateDto
{
    /// <summary>
    /// DTO for the process of adding a new character.
    /// </summary>

    public string Name { get; set; } = null!;
    public string Alias { get; set; } = null!;
    public string Gender { get; set; } = null!;
    public string PictureUrl { get; set; } = null!;
}
