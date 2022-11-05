using System;

namespace Model.Validator
{
    public class ValidationException : ApplicationException
    {
        public ValidationException(String message) : base(message) { }

    }

}
