namespace EFCoreDB.Util.Exeptions
{
    public class FranchiseNotFoundException : EntityNotFoundException
    {
        public FranchiseNotFoundException() : base("Franchise not found with that Id.")
        {
        }

    }
}
