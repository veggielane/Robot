using System;
using Microsoft.SPOT;

namespace Robot.Micro.Core
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
    }
}
