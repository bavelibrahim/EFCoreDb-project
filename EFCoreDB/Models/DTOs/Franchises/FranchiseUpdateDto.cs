namespace EFCoreDB.Models.DTOs.Franchises
{
    public class FranchiseUpdateDto
    {
        public int FranchiseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<MovieDto> Movies { get; set; }

    }
}
