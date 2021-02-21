using System;

namespace Bookshop.BussinesLogic.Exceptions
{
    public class ValidateShowcase: Exception
    {
        public ValidateShowcase(string message): base(message)
        { }
    }
}