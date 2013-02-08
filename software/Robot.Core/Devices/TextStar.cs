using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Robot.Core.Messaging;
using Robot.Core.Messaging.Messages;

namespace Robot.Core.Devices
{
    public class TextStar: IMessageOutput
    {
        private SerialPort _serial;

        public TextStar(IMessageBus bus)
        {
            bus.Add(new DebugMessage(string.Join(";", SerialPort.GetPortNames())));
        }
    }

    public interface IMessageOutput
    {
    }
}
