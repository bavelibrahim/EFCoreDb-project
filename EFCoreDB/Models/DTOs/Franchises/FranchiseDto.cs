using System.ComponentModel.DataAnnotations;

namespace EFCoreDB.Models.DTOs.Franchises
{
    public class FranchiseDto
    {
        public int FranchiseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
