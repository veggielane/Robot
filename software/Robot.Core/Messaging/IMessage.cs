using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot.Core.Messaging
{
    public interface IMessage
    {
        DateTime Time { get; }
    }
}
