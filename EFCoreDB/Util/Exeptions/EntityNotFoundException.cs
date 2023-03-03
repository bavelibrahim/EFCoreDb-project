using System;
namespace EFCoreDB.Util.Exeptions
{
<<<<<<< HEAD:EFCoreDB/Util/Exeptions/EntityNotFoundException.cs
    public class EntityNotFoundException : Exception
    {

        public EntityNotFoundException() { }
=======
    /// <summary>
    /// Parent "not found" exception for entities. Lets us have one catch in 
    /// controller methods where there are multiple possbilities of missing entities.
    /// </summary>
    public class EntityNotFoundException : Exception
    {
>>>>>>> origin/main:EFCoreDB/Util/Exeptions/EntityNotFoundExeption.cs
        public EntityNotFoundException(string? message) : base(message)
        {

        }

    }
}
