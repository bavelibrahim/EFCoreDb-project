namespace EFCoreDB.Models.DTOs.Franchises
{
    /// <summary>
    /// DTO for the process of adding a new Franchise.
    /// </summary>
    public class FranchiseCreateDto
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
