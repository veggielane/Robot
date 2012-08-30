using System;
namespace Robot.Core
{
    static class Error
    {
        public static Exception NotImplementedException()
        {
            return new NotImplementedException();
        }
        public static Exception ArgumentNullException(string e)
        {
            return new ArgumentNullException(e);
        }
        public static Exception ArgumentException(string e)
        {
            return new ArgumentException(e);
        }
    }

    public class ArgumentException : Exception
    {
        public ArgumentException(string message):base(message)
        {
            
        }
    }
}
