namespace EFCoreDB.Models.DTOs.Characters
{
    public class CharacterSummaryDto
    {
        /// <summary>
        /// DTO for a character without any related data.
        /// </summary>
        public int CharacterId { get; set; }
        public string Name { get; set; } = null!;
        public string Alias { get; set; } = null!;

    }
}
