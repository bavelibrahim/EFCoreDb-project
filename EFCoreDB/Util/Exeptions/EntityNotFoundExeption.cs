using System;
namespace EFCoreDB.Util.Exeptions
{
    public class EntityNotFoundExeption : Exception
    {

        public EntityNotFoundExeption() { }
        public EntityNotFoundException(string? message) : base(message)
        {

        }

    }
}
