using System;

namespace Model.Validator
{
    public class ExistentObjectException : ApplicationException
    {
        public ExistentObjectException(String message) : base(message) { }
    }
}
