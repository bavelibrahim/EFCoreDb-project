namespace EFCoreDB.Models.DTOs.Franchises
{
    /// <summary>
    /// DTO for a franchise without any related data.
    /// </summary>
    public class FranchiseSummaryDto
    {
        public int FranchiseId { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
