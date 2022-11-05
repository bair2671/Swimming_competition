using System;

namespace Service
{
    public class AppException : Exception
    {
        public AppException():base() { }

        public AppException(string msg) : base(msg) { }

        public AppException(string msg, Exception ex) : base(msg, ex) { }

    }
}