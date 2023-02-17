using System;

namespace FileManagement.Shared.Exceptions
{
    public class BaseException : SystemException
    {
        public BaseException(string message) : base(message)
        {

        }
    }
}
