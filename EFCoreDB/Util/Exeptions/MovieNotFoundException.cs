namespace EFCoreDB.Util.Exeptions
{
    public class MovieNotFoundException : EntityNotFoundException
    {
        public MovieNotFoundException() : base("Movie not found with that Id.")
        {
        }

    }
}
