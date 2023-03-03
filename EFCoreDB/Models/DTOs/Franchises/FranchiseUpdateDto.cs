namespace EFCoreDB.Models.DTOs.Franchises
{
    /// <summary>
    /// DTO for updating an existing Franchise. The related data is updated via a separate endpoint.
    /// </summary>
    public class FranchiseUpdateDto
    {
        public int FranchiseId { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

    }
}
