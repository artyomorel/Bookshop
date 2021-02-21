using System;

namespace Bookshop.BussinesLogic.Exceptions
{
    public class NotFoundException: Exception
    {
        public NotFoundException(string message) : base(message)
        { }
    }
}