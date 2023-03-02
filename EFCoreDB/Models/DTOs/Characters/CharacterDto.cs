using EFCoreDB.Models.DTOs.Movies;

public class CharacterDto
{
    public int CharacterId { get; set; }
    public string Name { get; set; }
    public string Alias { get; set; }
    public string Gender { get; set; }
    public string PictureUrl { get; set; }
    public List<MovieDto> Movies { get; set; }
}