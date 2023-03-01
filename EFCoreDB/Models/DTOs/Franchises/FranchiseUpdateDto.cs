namespace EFCoreDB.Models.DTOs.Franchises
{
    public class FranchiseUpdateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<MovieDto> Movies { get; set; }

    }
}
