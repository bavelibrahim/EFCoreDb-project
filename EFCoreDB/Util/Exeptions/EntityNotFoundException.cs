using System;
namespace EFCoreDB.Util.Exeptions
{
    public class EntityNotFoundException : Exception
    {

        public EntityNotFoundException() { }
        public EntityNotFoundException(string? message) : base(message)
        {

        }

    }
}
