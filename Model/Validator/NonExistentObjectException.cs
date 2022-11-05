using System;

namespace Proiect_MPP_GUI_Client_Server.Model.Validator
{
    public class NonExistentObjectException : ApplicationException
    {
        public NonExistentObjectException(String message) : base(message) { }
    }
}
