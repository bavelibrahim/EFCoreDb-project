
/// <summary>
/// General DTO for Character, which includes all related data as Ids.
/// </summary>
public class CharacterDto
{
    public int CharacterId { get; set; }
    public string Name { get; set; } = null!;
    public string Alias { get; set; } = null!;
    public string Gender { get; set; } = null!;
    public string PictureUrl { get; set; } = null!;
    public List<int> Movies { get; set; } = null!;
}