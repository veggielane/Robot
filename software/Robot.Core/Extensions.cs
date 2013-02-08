using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot.Core
{
    public static class Extensions
    {
        public static string Fmt(this string format, params object[] args)
        {
            return string.Format(format, args);
        }
    }
}
