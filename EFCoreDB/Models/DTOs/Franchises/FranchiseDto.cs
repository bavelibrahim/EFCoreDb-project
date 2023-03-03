using System.ComponentModel.DataAnnotations;

namespace EFCoreDB.Models.DTOs.Franchises
{

    /// <summary>
    /// General DTO for Franchise, which includes all related data as Ids.
    /// </summary>
    public class FranchiseDto
    {
        public int FranchiseId { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public List<int> Movies { get; set; } = null!;

    }
}
